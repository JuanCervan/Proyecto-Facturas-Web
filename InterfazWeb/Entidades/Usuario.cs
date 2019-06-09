using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazWeb.Entidades
{
    public class Usuario
    {
        int idUsuario;
        string nombre;
        string contrasenya;
        int acceso;
        string email;
        string pregunta;
        string respuesta;
       

        //constructor
        public Usuario(int idUsuario, string nombre, string contrasenya, int acceso,string email,string pregunta,string respuesta)
        {
            this.idUsuario = idUsuario;
            this.nombre = nombre;
            this.contrasenya = contrasenya;
            this.acceso = acceso;
            this.email = email;
            this.pregunta = pregunta;
            this.respuesta = respuesta;
          
        }

        //constructor vacio
        public Usuario() {
            this.idUsuario = -1;
            this.nombre = string.Empty;
            this.contrasenya = string.Empty;
            this.acceso = 3;
            this.email = string.Empty;
            this.pregunta = string.Empty;
            this.respuesta = string.Empty;
            

        }
        //constructor con registro
        public Usuario(DataSet1.UsuariosRow regUsuario)
        {
            this.idUsuario = regUsuario.IdUsuario;
            this.nombre = regUsuario.Nombre;
            this.contrasenya = regUsuario.Contraseña;
            this.acceso = regUsuario.Acceso;
            this.email = regUsuario.Email;
            this.pregunta = regUsuario.Pregunta;
            this.respuesta = regUsuario.Respuesta;
            
        }
       


        //get y set
        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }

            set
            {
                idUsuario = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Contrasenya
        {
            get
            {
                return contrasenya;
            }

            set
            {
                contrasenya = value;
            }
        }

        public int Acceso
        {
            get
            {
                return acceso;
            }

            set
            {
                acceso = value;
            }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Pregunta
        {
            get { return pregunta; }
            set { pregunta = value; }
        }
        public string Respuesta
        {
            get { return respuesta; }
            set { respuesta = value; }
        }

        

    }
}
