using ProjetoC._02_REPOSITORIO;
using ProjetoC._02_REPOSITORIO._01_CORE;
using ProjetoC._03_MODEL;
using ProjetoC._04_Dominio.Validar;
using System;
using System.Collections.Generic;

namespace ProjetoC._04_Dominio
{
    class PacienteServices : IServices<Paciente>
    {
        PacienteRepositorio repositorio = new PacienteRepositorio();

        public void Delete(Paciente _user)
        {
            bool verifica = repositorio.Delete(_user);
            if (verifica)
            {
            }
            else
            {
            }
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
            if (pacientes == null)
            {
            }
            return pacientes;
        }

        public void Insert(Paciente _user)
        {
            bool valida = ValidaPaciente.Validar(_user);

            try
            {
                if (valida == true )
                {
                    repositorio.Insert(_user);
                }
                else
                {
                }

            }
            catch (Exception msg)
            {
                Console.WriteLine("Alert Alert, Erro: " + msg.Message);
            }
        }

        public void Update(Paciente _user)
        {
            bool verifica = repositorio.Update(_user);
            if (verifica)
            {

            }
            else
            {
            }
        }
    }
}
