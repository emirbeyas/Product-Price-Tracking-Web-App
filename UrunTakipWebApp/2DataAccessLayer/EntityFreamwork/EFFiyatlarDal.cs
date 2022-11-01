using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1EntityLayer.Concrete;
using _2DataAccessLayer.Abstract;
using _2DataAccessLayer.Concrete.Repositories;

namespace _2DataAccessLayer.EntityFreamwork
{
    public class EFFiyatlarDal : GenericRepository<tbl_Fiyatlar>, IFiyatlarDal
    {
    }
}
