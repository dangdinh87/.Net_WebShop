using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.ModelDAO
{
  public class DanhMucDAO
    {
        Model1 db = null;
        public DanhMucDAO()
        {
            db = new Model1();
        }

        public List<DanhMuc> listDanhMuc()
        {
            return db.DanhMucs.ToList();
        }
    }
}
