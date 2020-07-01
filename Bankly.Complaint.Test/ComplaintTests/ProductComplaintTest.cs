using System;
using System.Threading.Tasks;
using Bankly.Complaint.Respository.Models;
using Bankly.Complaint.Service.Dto;
using Bankly.Complaint.Service.Factory;
using Xunit;

namespace Bankly.Complaint.Test.ComplaintTests
{
    [Collection("productcomplaint")]
    public class ProductComplaintTest
    {
        private readonly ProductComplaintFixture _productComplaintFixture;

        private ProductComplaintReqDto _productComplaintReqDto;

        private ProductComplaintUpdateDto _productComplaintUpdateDto;

        private ProductComplaint _productComplaint;

        public ProductComplaintTest(ProductComplaintFixture productComplaintFixture)
        {
            _productComplaintFixture = productComplaintFixture;

            _productComplaintReqDto = new ProductComplaintReqDto
            {
                Comment = "",
                ProductName = ""
            };

            _productComplaintUpdateDto = new ProductComplaintUpdateDto
            {
                Id = 0,
            };

            _productComplaint = new ProductComplaint
            {
                Id = 1
            };
        }

        [Fact]
        public async Task CreateProductComplaint_IsValidRequest_ReturnExecutionResponseFalse()
        {
            var result = await _productComplaintFixture.CreateComplaint(null);

            var exectutionResponse = Assert.IsType<ExecutionResponse<ProductComplaintDto>>(result);

            Assert.False(exectutionResponse.Status);
        }

        [Theory]
        [InlineData("","")]
        [InlineData("", " ")]
        [InlineData(null, " ")]
        [InlineData(" ", "")]
        [InlineData(null, "")]
        [InlineData(null, null)]
        public async Task CreateProductComplaint_RequireCommentandProductName_ReturnExecutionResponseFalse(string productName, string comment)
        {
            _productComplaintReqDto.ProductName = productName;
            _productComplaintReqDto.Comment = comment;

            var result = await _productComplaintFixture.CreateComplaint(_productComplaintReqDto);

            var exectutionResponse = Assert.IsType<ExecutionResponse<ProductComplaintDto>>(result);

            Assert.False(exectutionResponse.Status);

        }

        [Fact]
        public async Task CreateProductComplaint_CreateProductComplaintSucessful_ReturnExecutionResponseTrue()
        {

            _productComplaintReqDto.ProductName = "payment";
            _productComplaintReqDto.Comment = "very bad service";


            var result = await _productComplaintFixture.CreateComplaint(_productComplaintReqDto);

            var exectutionResponse = Assert.IsType<ExecutionResponse<ProductComplaintDto>>(result);

            Assert.True(exectutionResponse.Status);
        }


        [Fact]
        public async Task UpdateProductComplaint_IsValidRequest_ReturnExecutionResponseFalse()
        {
            var result = await _productComplaintFixture.UpdateComplaintStatus(null);

            var exectutionResponse = Assert.IsType<ExecutionResponse<ProductComplaintDto>>(result);

            Assert.False(exectutionResponse.Status);
        }

        [Fact]
        public async Task UpdateProductComplaint_InvalidComplaintRequestId_ReturnExecutionResponseFalse()
        {
            var result = await _productComplaintFixture.UpdateComplaintStatus(_productComplaintUpdateDto);

            var exectutionResponse = Assert.IsType<ExecutionResponse<ProductComplaintDto>>(result);

            Assert.False(exectutionResponse.Status);
        }

        [Fact]
        public async Task UpdateProductComplaint_ProductComplaintnotFound_ReturnExecutionResponseFalse()
        {
            _productComplaintUpdateDto.Id = 1;

            //setup
            _productComplaintFixture.GetByIdSetup(null);

            var result = await _productComplaintFixture.UpdateComplaintStatus(_productComplaintUpdateDto);

            var exectutionResponse = Assert.IsType<ExecutionResponse<ProductComplaintDto>>(result);

            Assert.False(exectutionResponse.Status);
        }

        [Fact]
        public async Task UpdateProductComplaint_ProductComplaintFoundandupdated_ReturnExecutionResponseTrue()
        {
            _productComplaintUpdateDto.Id = 1;

            //setup
            _productComplaintFixture.GetByIdSetup(_productComplaint);

            var result = await _productComplaintFixture.UpdateComplaintStatus(_productComplaintUpdateDto);

            var exectutionResponse = Assert.IsType<ExecutionResponse<ProductComplaintDto>>(result);

            Assert.True(exectutionResponse.Status);
        }

        [Fact]
        public async Task GetProductComplaint_InvalidComplaintId_ReturnExecutionResponseFalse()
        {

            var result = await _productComplaintFixture.GetComplaint(0);

            var exectutionResponse = Assert.IsType<ExecutionResponse<ProductComplaintDto>>(result);

            Assert.False(exectutionResponse.Status);
        }

        [Fact]
        public async Task GetProductComplaint_ProductComaplaintNotFound_ReturnExecutionResponseFalse()
        {
            //setup
            _productComplaintFixture.GetByIdAsNotrackingSetup(null);

            var result = await _productComplaintFixture.GetComplaint(1);

            var exectutionResponse = Assert.IsType<ExecutionResponse<ProductComplaintDto>>(result);

            Assert.False(exectutionResponse.Status);
        }

        [Fact]
        public async Task GetProductComplaint_ProductComaplaintFound_ReturnExecutionResponseTrue()
        {
            //setup
            _productComplaintFixture.GetByIdAsNotrackingSetup(_productComplaint);

            var result = await _productComplaintFixture.GetComplaint(1);

            var exectutionResponse = Assert.IsType<ExecutionResponse<ProductComplaintDto>>(result);

            Assert.True(exectutionResponse.Status);
        }
    }
}
