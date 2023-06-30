using System;
using System.Windows.Forms;

namespace SignoAscendenciaLuaApp
{
    public partial class FormSignoAscendenciaLua : Form
    {
        public FormSignoAscendenciaLua()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string genero = cmbGenero.SelectedItem.ToString();
            string local = txtLocal.Text;
            DateTime dataNascimento = dtDataNascimento.Value.Date;
            TimeSpan horarioNascimento;

            if (TimeSpan.TryParse(txtHorarioNascimento.Text, out horarioNascimento))
            {
                string signo = ObterSigno(dataNascimento);
                string ascendencia = ObterAscendencia(signo, horarioNascimento);
                string lua = ObterLua(genero, dataNascimento);

                string mensagem = "Nome: " + nome + "\n" +
                                  "Gênero: " + genero + "\n" +
                                  "Local: " + local + "\n" +
                                  "Data de Nascimento: " + dataNascimento.ToShortDateString() + "\n" +
                                  "Horário de Nascimento: " + horarioNascimento.ToString() + "\n\n" +
                                  "Signo: " + signo + "\n" +
                                  "Ascendência: " + ascendencia + "\n" +
                                  "Lua: " + lua;

                MessageBox.Show(mensagem, "Informações", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Horário de Nascimento inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObterSigno(DateTime dataNascimento)
        {
            int dia = dataNascimento.Day;
            int mes = dataNascimento.Month;

            if ((mes == 3 && dia >= 21) || (mes == 4 && dia <= 19))
                return "Áries";
            else if ((mes == 4 && dia >= 20) || (mes == 5 && dia <= 20))
                return "Touro";
            else if ((mes == 5 && dia >= 21) || (mes == 6 && dia <= 20))
                return "Gêmeos";
            else if ((mes == 6 && dia >= 21) || (mes == 7 && dia <= 22))
                return "Câncer";
            else if ((mes == 7 && dia >= 23) || (mes == 8 && dia <= 22))
                return "Leão";
            else if ((mes == 8 && dia >= 23) || (mes == 9 && dia <= 22))
                return "Virgem";
            else if ((mes == 9 && dia >= 23) || (mes == 10 && dia <= 22))
                return "Libra";
            else if ((mes == 10 && dia >= 23) || (mes == 11 && dia <= 21))
                return "Escorpião";
            else if ((mes == 11 && dia >= 22) || (mes == 12 && dia <= 21))
                return "Sagitário";
            else if ((mes == 12 && dia >= 22) || (mes == 1 && dia <= 19))
                return "Capricórnio";
            else if ((mes == 1 && dia >= 20) || (mes == 2 && dia <= 18))
                return "Aquário";
            else
                return "Peixes";
        }

        private string ObterAscendencia(string signo, TimeSpan horarioNascimento)
        {
            if (horarioNascimento >= new TimeSpan(6, 31, 0) && horarioNascimento <= new TimeSpan(8, 30, 0))
            {
                return "Áries";
            }
            else if (horarioNascimento >= new TimeSpan(8, 31, 0) && horarioNascimento <= new TimeSpan(10, 30, 0))
            {
                return "Touro";
            }
            else if (horarioNascimento >= new TimeSpan(10, 31, 0) && horarioNascimento <= new TimeSpan(12, 30, 0))
            {
                return "Gêmeos";
            }
            else if (horarioNascimento >= new TimeSpan(12, 31, 0) && horarioNascimento <= new TimeSpan(14, 30, 0))
            {
                return "Câncer";
            }
            else if (horarioNascimento >= new TimeSpan(14, 31, 0) && horarioNascimento <= new TimeSpan(16, 30, 0))
            {
                return "Leão";
            }
            else if (horarioNascimento >= new TimeSpan(16, 31, 0) && horarioNascimento <= new TimeSpan(18, 30, 0))
            {
                return "Virgem";
            }
            else if (horarioNascimento >= new TimeSpan(18, 31, 0) && horarioNascimento <= new TimeSpan(20, 30, 0))
            {
                return "Libra";
            }
            else if (horarioNascimento >= new TimeSpan(20, 31, 0) && horarioNascimento <= new TimeSpan(22, 30, 0))
            {
                return "Escorpião";
            }
            else if (horarioNascimento >= new TimeSpan(22, 31, 0) || horarioNascimento <= new TimeSpan(0, 30, 0))
            {
                return "Sagitário";
            }
            else if (horarioNascimento >= new TimeSpan(0, 31, 0) && horarioNascimento <= new TimeSpan(2, 30, 0))
            {
                return "Capricórnio";
            }
            else if (horarioNascimento >= new TimeSpan(2, 31, 0) && horarioNascimento <= new TimeSpan(4, 30, 0))
            {
                return "Aquário";
            }
            else if (horarioNascimento >= new TimeSpan(4, 31, 0) && horarioNascimento <= new TimeSpan(6, 30, 0))
            {
                return "Peixes";
            }
            else
            {
                return "Ascendência não encontrada";
            }
        }

        private string ObterLua(string genero, DateTime dataNascimento)
        {
            int dia = dataNascimento.Day;
            int mes = dataNascimento.Month;
            int ano = dataNascimento.Year;

            DateTime dataReferencia = new DateTime(1900, 1, 1);
            DateTime dataNascimentoReferencia = new DateTime(ano, mes, dia);

            int diasTotais = (int)(dataNascimentoReferencia - dataReferencia).TotalDays;
            int fasesDaLua = (diasTotais / 29) % 8;

            string lua = string.Empty;

            switch (fasesDaLua)
            {
                case 0:
                    lua = "Lua Nova";
                    break;
                case 1:
                    lua = "Lua Crescente";
                    break;
                case 2:
                    lua = "Quarto Crescente";
                    break;
                case 3:
                    lua = "Gibosa Crescente";
                    break;
                case 4:
                    lua = "Lua Cheia";
                    break;
                case 5:
                    lua = "Gibosa Minguante";
                    break;
                case 6:
                    lua = "Quarto Minguante";
                    break;
                case 7:
                    lua = "Lua Minguante";
                    break;
                default:
                    lua = "Fase da Lua não identificada";
                    break;
            }

            if (genero == "Masculino")
            {
                return "Lua masculina - " + lua;
            }
            else if (genero == "Feminino")
            {
                return "Lua feminina - " + lua;
            }
            else
            {
                return "Lua não encontrada";
            }
        }
    }
}
