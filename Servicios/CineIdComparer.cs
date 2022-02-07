using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePeliculas.Servicios
{
    public class CineIdComparer : IEqualityComparer<CineDTO>
    {
        public bool Equals([AllowNull] CineDTO x, [AllowNull] CineDTO y)
        {
           return x?.Id == y?.Id;
        }

        public int GetHashCode([DisallowNull] CineDTO obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
