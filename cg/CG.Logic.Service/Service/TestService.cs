using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.DataAccess.Repositories;
using CG.Access.DataAccess.RepositoryInterface;
using CG.Access.MessageBus.Clients;
using CG.Access.MessageBus.Message;
using CG.Logic.Domain.OrderPrinting;
using CG.Logic.DomainObject;
using CG.Logic.Dto;
using CG.Logic.Dto.TestDtos;
using CG.Logic.Service.Interface;
using Microsoft.Practices.Unity;

namespace CG.Logic.Service.Service
{
    public class TestService : ITestService
    {
        [Dependency]
        public ITestRepository TestRepository { get; set; }

        [Dependency]
        public IOrderPrintingMessageBusClient OrderPrintingMessageBusClient { get; set; }

        public ResponseDto<TestObjectDto> GetTestMessageById(long messageId)
        {
            var testMessage = TestRepository.GetTestMessageById(messageId);
            if (testMessage != null)
            {
                return new ResponseDto<TestObjectDto>
                {
                    IsSuccessful = true,
                    Payload = new TestObjectDto
                    {
                        Id = testMessage.Id,
                        Message = testMessage.Description,
                    }
                };
            }
            
            return new ResponseDto<TestObjectDto>
                {
                    IsSuccessful = true,
                    Payload = new TestObjectDto
                        {
                            Id = 33,
                            Message = "Test Message"
                        }
                };

            var failedResponse = new ResponseDto<TestObjectDto>
            {
                IsSuccessful = false,
            };
            
            failedResponse.Messages.Add(new MessageDto
            {
                Code = "Data not find",
                Message = string.Format("Cannot find Messge from DB by ID : {0}", messageId),
            });

            return failedResponse;
        }

        public VoidResponseDto PublishMessage(TestObjectDto testObjectDto)
        {
            var queueMessage = new QueueMessage<OrderPrintingMessage>
            {
                MessageContent = new OrderPrintingMessage
                {
                    OrderDetail = testObjectDto.Message,
                }
            };

            var response = new VoidResponseDto();

            try
            {
                OrderPrintingMessageBusClient.Publish(queueMessage);
                response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
            }

            return response;
        }
    }
}
