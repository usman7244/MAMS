using DAL.Sql;
using Dapper;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Linq;

namespace DAL
{
    public class SaleDAL
    {
        private Sale _sale;
        private List<Sale> _sales;
        public SaleDAL( )
        {
            _sale=new Sale();
            _sales=new List<Sale>();
        }
        public async Task<int> Insert(Sale param, ISqlConnectionFactory connectionFactory)
        {
            await using var connection = connectionFactory.CreateConnection();
            string SQLQuery = @"EXEC [dbo].[spCreateSaleCrop]
                                     @UID ,
	                                 @CustomerType ,
	                                 @Fk_CustomerId ,
	                                 @Fk_Crop,
	                                 @WeightInMaun ,
	                                 @WeightInkg,
	                                 @TotalCropWeight ,
	                                 @PriceInMaun ,
	                                 @PriceInKg ,
	                                 @TotalCropPrice ,
	                                 @TotalExp ,
	                                 @TotalAmountwithExp ,
	                                 @FK_BagType ,
	                                 @BagWeight ,
	                                 @BagTotal ,
                                     @BagTotal ,
                                     @PurchaseExp ,
	                                 @CreatedBy,
                                     @BranchId
                                     ";

            var res = await connection.QueryFirstOrDefaultAsync<int>(SQLQuery, param, null);

            return res;
        }
        public async Task<int> Delete(Sale param, ISqlConnectionFactory connectionFactory)
        {
            await using var connection = connectionFactory.CreateConnection();
            string SQLQuery = @" EXEC [dbo].[spDeleteSaleCrop]
                                       @ModifiedBy,
                                       @UID;"  ;

            await connection.ExecuteAsync(SQLQuery, param, null);
            return 1;
        }
        public async Task<int> Update(Sale param, ISqlConnectionFactory connectionFactory)
        {
            await using var connection = connectionFactory.CreateConnection();
            string SQLQuery = @" EXEC [dbo].[spUpdateSaleCrop]
                                         @UID ,
	                                     @Fk_CustomerId ,
	                                     @Fk_Crop ,
	                                     @WeightInMaun ,
	                                     @WeightInkg ,
	                                     @TotalCropWeight ,
	                                     @PriceInMaun ,
	                                     @PriceInKg ,
	                                     @TotalCropPrice ,
	                                     @TotalExp , 
	                                     @TotalAmountwithExp , 
	                                     @FK_BagType ,
	                                     @BagWeight ,
	                                     @BagTotal ,
	                                     @PurchaseExp ,
	                                     @PurchasePrice ,
	                                     @ModifiedBy  ";

            var res = await connection.QueryFirstOrDefaultAsync<int>(SQLQuery, param, null);
            return res;
        }
        public async Task<Sale> GetById(Sale param, ISqlConnectionFactory connectionFactory)
        {
            _sale =new Sale();
            await using var connection = connectionFactory.CreateConnection();
            string SQLQuery = @" EXEC [dbo].[spGetSaleCropById]
		                                    @UID   ";

             _sale = await connection.QueryFirstOrDefaultAsync<Sale>(SQLQuery, param, null); 
            return _sale;
        }
        public async Task<List<Sale>> GetAll(Sale param, ISqlConnectionFactory connectionFactory)
        {
            _sales = new List<Sale>();
            await using var connection = connectionFactory.CreateConnection();
            string SQLQuery = @" EXEC [dbo].[spGetAllSaleCrop]
                                        @BranchId ,
		                                @CreatedBy ; ";

            var result = await connection.QueryMultipleAsync(SQLQuery, param, null);
            _sales = result.Read<Sale>().ToList();
            return _sales;
        }
    }
}
