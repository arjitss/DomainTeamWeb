using System.Collections.Generic;
using System.Linq;

namespace DomainTeamWebsite.Models{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List <Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>(){
                new Employee() {Id = 1, Name = "Arjit", Email = "arjit.sharma@gmail.com", CoreSkills = "Azure"},
                new Employee() {Id = 2, Name = "Test Data 2", Email = "Test.Data@gmail.com", CoreSkills = "Data"},
                new Employee() {Id = 3, Name = "Testing 3", Email = "Testing@gmail.com", CoreSkills = "Testing"}
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public Employee Add(Employee employee){
            
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }
    }
}