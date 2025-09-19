﻿using EmpSkillHub.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllAsync();
    Task<Employee> GetByIdAsync(int id);
    Task AddAsync(Employee employee);
    Task<bool> ExistsAsync(string firstName,string lastName, string phoneNumber);
}