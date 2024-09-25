using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;
        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public void  CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            string query = "INSERT INTO Employee (Name, Title, Mail, PhoneNumber, ImageUrl, Status) VALUES (@name, @title, @mail, @phoneNumber, @imageUrl, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createEmployeeDto.Name);
            parameters.Add("@title", createEmployeeDto.Title);
            parameters.Add("@mail", createEmployeeDto.Mail);
            parameters.Add("@phoneNumber", createEmployeeDto.PhoneNumber);
            parameters.Add("@imageUrl", createEmployeeDto.ImageUrl);
            parameters.Add("@status", true); // Employee is created with a default status of true

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }

        public void DeleteEmployee(int id)
        {
            string query = "DELETE FROM Employee WHERE EmployeeID = @employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "SELECT * FROM Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }


        public async Task<GetByIdEmployeeDto> GetEmployee(int id)
        {
            string query = "SELECT * FROM Employee WHERE EmployeeID = @EmployeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeID", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query, parameters);
                return values;
            }
        }

        public void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "UPDATE Employee SET Name = @name, Title = @title, Mail = @mail, PhoneNumber = @phoneNumber, ImageUrl = @imageUrl, Status = @status WHERE EmployeeID = @employeeId";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateEmployeeDto.Name);
            parameters.Add("@title", updateEmployeeDto.Title);
            parameters.Add("@mail", updateEmployeeDto.Mail);
            parameters.Add("@phoneNumber", updateEmployeeDto.PhoneNumber);
            parameters.Add("@imageUrl", updateEmployeeDto.ImageUrl);
            parameters.Add("@status", updateEmployeeDto.Status);
            parameters.Add("@employeeId", updateEmployeeDto.EmployeeID);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }
    }
}
