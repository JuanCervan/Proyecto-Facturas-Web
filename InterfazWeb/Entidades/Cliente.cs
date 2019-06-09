using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazWeb.Entidades
{
    public class Cliente
    {
        int idCliente;
        string nombre;
        string cif;
        string direccion;
        string ciudad;
        string telefono;
        string email;
        string persona;
        int idUsuario;

        //constructor
        public Cliente(int idCliente, string nombre, string cif, string direccion, string ciudad, string telefono, string email, string persona,int idUsuario)
        {
            this.IdCliente = idCliente;
            this.Nombre = nombre;
            this.Cif = cif;
            this.Direccion = direccion;
            this.Ciudad = ciudad;
            this.Telefono = telefono;
            this.Email = email;
            this.Persona = persona;
            this.idUsuario = idUsuario;
        }

        //constructor vacio
        public Cliente()
        {
            this.idCliente = -1;
            this.Nombre = String.Empty;
            this.Cif = String.Empty;
            this.Direccion = String.Empty;
            this.Ciudad = String.Empty;
            this.Telefono = String.Empty;
            this.Email = String.Empty;
            this.Persona = String.Empty;
            this.idUsuario = 0;
            

        }

        //constructor con registro
        public Cliente(DataSet1.ClientesRow regCliente)
        {
            this.idCliente = regCliente.IdCliente;
            this.nombre = regCliente.Nombre;
            this.cif = regCliente.Cif;
            this.direccion = regCliente.Direccion;
            this.ciudad = regCliente.Ciudad;
            this.telefono = regCliente.Telefono;
            this.email = regCliente.email;
            this.persona = regCliente.Persona;
            this.idUsuario = regCliente.IdUsuario;
        }
        public int IdCliente
        {
            get
            {
                return idCliente;
            }

            set
            {
                idCliente = value;
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

        public string Cif
        {
            get
            {
                return cif;
            }

            set
            {
                cif = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string Ciudad
        {
            get
            {
                return ciudad;
            }

            set
            {
                ciudad = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Persona
        {
            get
            {
                return persona;
            }

            set
            {
                persona = value;
            }
        }
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

    }
    }
