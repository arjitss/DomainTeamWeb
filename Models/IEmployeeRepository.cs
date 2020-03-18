using System.Collections.Generic;

namespace DomainTeamWebsite.Models{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        IEnumerable <Employee> GetAllEmployees();
        Employee Add(Employee employee);
    }   
    
}