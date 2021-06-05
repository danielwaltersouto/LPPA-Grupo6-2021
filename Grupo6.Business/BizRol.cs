﻿using Grupo6.Data.Services;
using Grupo6.Entities.Models;
using System.Collections.Generic;

namespace Grupo6.Business
{
    public class BizRol
    {
        public void Agregar(Rol rol)
        {
            var db = new BaseDataService<Rol>();
            db.Create(rol);

        }

        public List<Rol> TraerTodos()
        {
            var db = new BaseDataService<Rol>();
            var lista = db.Get();
            return lista;
        }

        public Rol TraerPorId(int id)
        {
            var db = new BaseDataService<Rol>();
            return db.GetById(id);
        }

        public void Eliminar(Rol rol)
        {
            var db = new BaseDataService<Rol>();
            db.Delete(rol);
        }

        public void Actualizar(Rol rol)
        {
            var db = new BaseDataService<Rol>();
            db.Update(rol);
        }
    }
}
