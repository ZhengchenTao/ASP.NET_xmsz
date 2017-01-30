using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biz.Entity;

namespace Biz
{
    public class GetDistricts
    {
        Db db = new Db();
        public IList<District> selectProvince()
        {
            return db.district.Where(d => d.parent_id == 0).ToList();
        }
        public IList<District> selectCity(int provinceId)
        {
            IList<District> re = db.district.Where(d => d.parent_id == provinceId).ToList();
            if (re[0] == null)
            {
                return db.district.Where(d => d.id == provinceId).ToList();
            }
            else
            {
                return re;
            }
        }

    }
}
