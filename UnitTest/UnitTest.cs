using System.Linq;
using Core.Entity;
using Dapper;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void TestDataBaseConnection()
        {
            //string sql = $"UPDATE [User] SET IsDeleted = @IsDeleted WHERE IsDeleted = @IsDeleted";
            //CoreApiContext.Dapper.Execute(sql, new { IsDeleted = false });
            CoreApiContext context = new CoreApiContext();
            Assert.IsTrue(context.User.Any(), "���ݿ���������");
        }

        [Test]
        public void AddNumberTest()
        {
            int i = 5, j = 6;
            int result = 11;
            Assert.AreNotEqual(result, i + j, "test fail");
        }
    }
}
