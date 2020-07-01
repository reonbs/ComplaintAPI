using System;
using Xunit;

namespace Bankly.Complaint.Test.ComplaintTests
{
    [CollectionDefinition("productcomplaint")]
    public class ProductComplaintCollectionFixture: ICollectionFixture<ProductComplaintFixture>
    {
        public ProductComplaintCollectionFixture()
        {
        }
    }
}
