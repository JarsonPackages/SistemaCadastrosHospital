using ProjetoC._02_REPOSITORIO;
using ProjetoC._02_REPOSITORIO._01_CORE;
using ProjetoC._03_MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoC._04_Dominio
{
    class MedicoServices : IServices<Medico>
    {
        MedicoRepositorio repositorio = new MedicoRepositorio();

        public void Delete(Medico _user)
        {
            bool verifica = repositorio.Delete(_user);
            if (verifica)
            {
                System.Windows.Forms.MessageBox.Show("Medico Excluido");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Erro ao Excluir Medico");
            }
        }

        public Medico Get(int _user)
        {
            var _medico = repositorio.GetById(_user);
            if (_medico == null)
            {
                System.Windows.Forms.MessageBox.Show("Paciente nao encontrado");

            }
            return _medico;
        }

        public List<Medico> GetAll()
        {
            List<Medico> pacientes = new List<Medico>();
            pacientes = repositorio.GetAll();
            if (pacientes == null)
            {
                System.Windows.Forms.MessageBox.Show("Medico nao encontrado");
            }
            return pacientes;
        }

        public void Insert(Medico _user)
        {
            
        }

        public void Update(Medico _user)
        {
            throw new NotImplementedException();
        }
    }
}
