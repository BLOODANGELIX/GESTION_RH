    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ejemplo.Models
    {
        // Dado que en algunos casos el id es un string y en otros es un int se usa Tkey para especificar el tipo de id
        // Y T es el tipo de modelo que se vaya a usar en cada repositorio
        public interface IBaseRepository<T,Tkey>
        {
            void Add(T modelo);
            void Edit(T modelo);
            void Remove(Tkey id);
            T GetById(Tkey id);
            IEnumerable<T> GetAll();
        }
    }
