using DAL.Sql;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class CompanyBOL
    {
        private DAL.CompanyDAL _objCompanyDAL;
        public CompanyBOL()
        {
            _objCompanyDAL = new DAL.CompanyDAL();

        }
        public async Task<List<Company>> GetCompanyInfo( ISqlConnectionFactory connectionFactory)
        {
            var result = await _objCompanyDAL.GetCompanyInfo( connectionFactory);
            return result;
        }
        public async Task<int> CompanyAdd(Company company, ISqlConnectionFactory connectionFactory)
        {
            int affectedRows = 0;
            if (company != null)
            {
                affectedRows = await _objCompanyDAL.CompanyAdd(company, connectionFactory);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }
        public Task<int> DeleteCompany(Company company, ISqlConnectionFactory connectionFactory)
        {
            return _objCompanyDAL.DeleteCompany(company, connectionFactory);
        }
        public async Task<Company> GetSpecificCompanyInfo(Guid Id, ISqlConnectionFactory connectionFactory)
        {
            var result = await _objCompanyDAL.GetSpecificCompanyInfo(Id, connectionFactory);
            return result;
        }
        public async Task<int> EditCompany(Company company, ISqlConnectionFactory connectionFactory)
        {
            int affectedRows = 0;
            if (company != null)
            {
                affectedRows = await _objCompanyDAL.EditCompany(company, connectionFactory);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }
    }
}
