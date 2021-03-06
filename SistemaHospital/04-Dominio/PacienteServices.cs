﻿using ProjetoC._02_REPOSITORIO;
using ProjetoC._02_REPOSITORIO._01_CORE;
using ProjetoC._03_MODEL;
using ProjetoC._04_Dominio.Validar;
using System;
using System.Collections.Generic;

namespace ProjetoC._04_Dominio
{
    class PacienteServices : IServices<Paciente>,IDisposable
    {
        PacienteRepositorio repositorio = new PacienteRepositorio();

        public bool Delete(Paciente _user)
        {
            return repositorio.Delete(_user);

        }

        public void Dispose()
        {
          
          
        }

        public Paciente Get(int _user)
        {
            var _paciente = repositorio.GetById(_user);
            if (_paciente == null)
            {

            }
            return _paciente;
        }

        public List<Paciente> GetAll()
        {
            List<Paciente> pacientes = new List<Paciente>();
            pacientes = repositorio.GetAll();
            
            return pacientes;
        }

        public bool Insert(Paciente _user)
        {
            if(ValidaPaciente.validar(_user))
            {

                return repositorio.Insert(_user);
            }
            else
            {
                return false;
                
            }
        }
        public bool Update(Paciente _user)
        {
            bool verifica = repositorio.Update(_user);
            return verifica;
        }
    }
}
