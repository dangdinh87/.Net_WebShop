using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.ModelDAO
{
   public  class SanPhamDAO
    {
        Model1 db = null;
        public SanPhamDAO()
        {
            db = new Model1();
        }

        public List<SanPham> listSanPham()
        {
            return db.SanPhams.ToList();
        }
    }
}
