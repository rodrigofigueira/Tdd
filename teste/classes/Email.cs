namespace teste.classes
{
    public class Email
    {
        private string _email { get; set; }
        private string[] caracteresInvalidos = {"&", "=", "_", "'", "-", "+", ",", "<", ">"};        

        private string[] caracteresValidos = {"@", "."};

        public Email(string email){
            this._email = email;
        }

        public string Validar(){            

            if (ExisteEspacoEmBranco()) 
                return "Não pode ter espaços em branco";

            if(ExisteCaracteresInvalidos())
                return "Email com caracteres inválidos";

            if(UltimoCaracterEInvalido())
                return "Email com caracteres inválidos";

            if(TamanhoMaximoInvalido())
                return "Email não pode ter mais de 20 caracteres";

            if(!TemTodosCaracteresEspeciaisNecessarios())
                return "Email não tem os caracteres especiais necessários";

            if(TamanhoMinimoInvalido())
                return "Email deve ser maior que 5 caracteres";

            return "Email válido"; 

        }

        private bool ExisteEspacoEmBranco(){
            if(this._email.Trim().Contains(" ")) return true;
            return false;
        }

        private bool ExisteCaracteresInvalidos(){

            bool temCaracterInvalido = false;

            foreach(var caracter in this.caracteresInvalidos){
                if(this._email.Contains(caracter)) temCaracterInvalido = true;
            } 

            return temCaracterInvalido;
        }

        private bool UltimoCaracterEInvalido(){
            var ultimoCaracter = this._email.Substring(this._email.Length - 1, 1);

            if(ultimoCaracter == ".") return true;

            return false;
        }

        private bool TamanhoMaximoInvalido(){
            if(this._email.Length > 20)
                return true;

            return false;
        }

        private bool TemTodosCaracteresEspeciaisNecessarios(){

            bool temTodosOsCaracteres = true;

            foreach(var caracter in this.caracteresValidos){
                if(!this._email.Contains(caracter)) temTodosOsCaracteres = false;
                break;
            } 

            return temTodosOsCaracteres;            
        }

        private bool TamanhoMinimoInvalido(){
            if(this._email.Length < 6) return true;
            return false;
        }

    }
}