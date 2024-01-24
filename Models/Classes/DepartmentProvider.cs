using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class DepartmentProvider
    {
        private readonly Context _context;

        public DepartmentProvider(Context context){

            _context = context;
        }
        private List<Department> depList;

        private DepartmentProvider(){
            depList = _context.Departments.Where(x => x.isActive == true).Include(x => x.Employees).ToList();
        }

        static bool isCreated = false;

        static public DepartmentProvider instance;

        static public DepartmentProvider Instance
        {
            get
            {
                if (isCreated)
                {
                    return instance;
                }
                else
                {
                    instance = new DepartmentProvider();
                    isCreated = true;
                    return instance;
                }
            }   
        }

        public async Task<List<Department>> GetDepList()
        {
            return depList;
        }
    }
}