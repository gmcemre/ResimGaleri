using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimGaleri.ORM.Entity
{
    public class UrunResim
    {
        public int Id { get; set; }
        public int UrunID { get; set; }
        public byte[] Resim { get; set; }
        public bool IsActive { get; set; }
    }
}
