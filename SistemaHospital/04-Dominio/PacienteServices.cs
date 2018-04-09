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
                System.Windows.Forms.MessageBox.Show("Paciente Excluido");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Erro ao Excluir Paciente");
            }
        }

        public Paciente Get(int _user)
        {
            var _paciente = repositorio.GetById(_user);
            if (_paciente == null)
            {
                System.Windows.Forms.MessageBox.Show("Paciente nao encontrado");

            }
            return _paciente;
        }

        public List<Paciente> GetAll()
        {
            List<Paciente> pacientes = new List<Paciente>();
            pacientes = repositorio.GetAll();
            if (pacientes == null)
            {
                System.Windows.Forms.MessageBox.Show("Pacientes nao encontrado");
            }
            return pacientes;
        }

        public void Insert(Paciente _user)
        {
            bool valida = ValidaPaciente.Validar(_user);

            try
            {
                if (valida == true && ApiCorreios.valida == true)
                {
                    repositorio.Insert(_user);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Paciente não cadastrado");
                }

            }
            catch (Exception erro)
            {
                System.Windows.Forms.MessageBox.Show(erro.Message);
            }
        }

        public void Update(Paciente _user)
        {
            bool verifica = repositorio.Update(_user);
            if (verifica)
            {
                System.Windows.Forms.MessageBox.Show("Atualizado com sucesso");

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Erro ao atualizar");
            }
        }
    }
}
