using DC;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Problem1WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceProblem1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceProblem1.svc or ServiceProblem1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceProblem1 : IServiceProblem1
    {
        private Problem1DCDataContext dtContext = new Problem1DCDataContext();

        /// <summary>
        /// Método para registrar o Cliente.
        /// </summary>
        /// <param name="nome">Informe o Nome do Cliente.</param>
        /// <param name="email">Informe o Email do Cliente.</param>
        /// <param name="data">Informe a Data de Nascimento do Cliente. Formato dd/MM/aaaa [d-Dia; M-Mês; a-Ano]</param>
        /// <param name="celular">Informe o Celular do Cliente.</param>
        /// <param name="telefoneResidencial">Informe o Telefone Residencial do Cliente.</param>
        /// <returns>Retorna o resultado da execução do método.</returns>
        public string RegisterClient(string nome, string email, string data, string celular, string telefoneResidencial)
        {
            string result = string.Empty;

            if (ValidarDados(nome, email, data, celular, telefoneResidencial, ref result))
            {
                SalvarPessoa(nome, email, data, celular, telefoneResidencial, ref result);
            }

            return result;
        }

        #region Métodos Auxiliares
        private void SalvarPessoa(string nome, string email, string data, string celular, string telefoneResidencial, ref string result)
        {
            try
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = nome;
                pessoa.Email = email;
                pessoa.DataDeNascimento = DateTime.ParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                pessoa.Celular = celular;
                pessoa.TelefoneResidencial = telefoneResidencial;
                dtContext.Pessoas.InsertOnSubmit(pessoa);
                dtContext.SubmitChanges();
                result = "Dados salvo com sucesso!";
            }
            catch (Exception ex)
            {
                result = "Erro ao salvar: " + ex.Message;
            }
        }

        private bool ValidarDados(string nome, string email, string data, string celular, string telefoneResidencial, ref string result)
        {
            bool retorno = true;
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, ".+\\@.+\\..+"))
            {
                result += string.Format("- Email inválido. ({0})\n", email);
                retorno = false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(celular, @"^([\+]\d{2}[- .]?)?[01]?[- .]?(\(\d{2}\)|\d{2}|\(\d{3}\)|\d{3})?[- .]?(\d{4}|\d{5})[- .]?\d{4}$"))
            {
                result += string.Format("- Celular inválido. ({0})\n", email);
                retorno = false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(telefoneResidencial, @"^([\+]\d{2}[- .]?)?[01]?[- .]?(\(\d{2}\)|\d{2}|\(\d{3}\)|\d{3})?[- .]?(\d{4}|\d{5})[- .]?\d{4}$"))
            {
                result += string.Format("- Telefone Residencial inválido. ({0})\n", email);
                retorno = false;
            }
            try
            {
                DateTime dataDeNascimento = DateTime.ParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (dataDeNascimento.CompareTo(DateTime.Today) == 1)
                {
                    result += string.Format("- Data de nascimento errada. ({0})\n", data);
                    retorno = false;
                }
            }
            catch
            {
                result += string.Format("- Data inválida. Use o formato dd/MM/aaa[d-Dia; M-Mês; a-Ano] ({0})\n", data);
                retorno = false;
            }
            return retorno;
        }
        #endregion
    }
}
