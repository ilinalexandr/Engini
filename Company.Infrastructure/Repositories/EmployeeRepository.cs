using Company.Infrastructure.Data;
using Company.Infrastructure.Repositories.Interfaces;
using Company.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<EmployeeEntity>, IEmployeeRepository
    {
        //MySQL
        private const string hierarchySql = @"WITH RECURSIVE EmployeeHierarchy AS (
                            SELECT *
                            FROM Employees
                            WHERE Id = {0}
    
                            UNION ALL
    
                            SELECT e.*
                            FROM Employees e
                            JOIN EmployeeHierarchy eh ON e.ManagerId = eh.Id
                        )
                        SELECT * FROM EmployeeHierarchy;";

        public EmployeeRepository(CompanyDbContext context) : base(context)
        {
        }

        public List<EmployeeEntity> GetEmployeeHierarchyFlat(int id)
        {
            var sql = string.Format(hierarchySql, id);

            var employees = _context.Employees.FromSqlRaw(sql, id).ToList();

            return employees;
        }
    }
}
