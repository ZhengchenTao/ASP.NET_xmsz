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
            if (re.Count == 0)
            {
                return db.district.Where(d => d.id == provinceId).ToList();
            }
            else
            {
                return re;
            }
        }
        public string showProvinceCtity(int id)
        {
            District city = db.district.SingleOrDefault(d => d.id == id);
            if (city == null)
            {
                return "未选择城市";
            }
            if (city.parent_id == 0)
            {
                return city.name;
            }
            District province = db.district.SingleOrDefault(d => d.id == city.parent_id);
            return province.name + "," + city.name;
        }
        public District getProvince(int id)
        {
            return db.district.SingleOrDefault(a => a.id == id);
        }
    }
}
