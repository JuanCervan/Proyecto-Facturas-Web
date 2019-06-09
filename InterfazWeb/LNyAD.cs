using InterfazWeb.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterfazWeb.Entidades;
namespace InterfazWeb
{
    public class LNyAD
    {
        //ACCESO
        static AccesoTableAdapter accesosAdapter = new AccesoTableAdapter();
        static DataSet1.AccesoDataTable accesosTabla = new DataSet1.AccesoDataTable();
        
        //USUARIOS
        static UsuariosTableAdapter usuariosAdapter = new UsuariosTableAdapter();
        static DataSet1.UsuariosDataTable usuariosTabla = new DataSet1.UsuariosDataTable();
        static DataSet1.UsuariosDataTable usuarioActivo = new DataSet1.UsuariosDataTable();
        static DataSet1.UsuariosDataTable usuarioPerfil = new DataSet1.UsuariosDataTable();

        //CLIENTES
        static ClientesTableAdapter clientesAdpater = new ClientesTableAdapter();

        public static int CuentaConceptos()
        {
            int numConceptos = Convert.ToInt32(conceptosAdapter.NumeroConceptos());
            return numConceptos;
        }

        internal static string TipoUsuario(int acceso)
        {
            string tipo = accesosAdapter.NombreAccesoPorId(acceso)[0].Nombre;
            return tipo;
        }

        public static DataSet1.ConceptosDataTable CargaConceptos()
        {
            conceptosTabla = conceptosAdapter.GetData();
            return conceptosTabla;
        }

        internal static List<Acceso> CargaAccesos()
        {
            List<Acceso> listAcceso = new List<Acceso>();
            accesosTabla = accesosAdapter.GetData();
            foreach(DataSet1.AccesoRow a in accesosTabla)
            {
                listAcceso.Add(new Acceso(a));
            }
            return listAcceso;

        }

        public static string CuotaIvaGlobal(int idFactura)
        {
            double cuotaIvaGlobal = Convert.ToDouble(lineasAdapter.GlobalCuotaIvaPorIdFactura(idFactura));
            return cuotaIvaGlobal.ToString("0.00 €");
        }

        internal static int IdUsuarioCliente(int idCliente)
        {
            int idUsuario = clientesAdpater.IdUsuariodeCliente(idCliente)[0].IdUsuario;
            return idUsuario;
        }

        internal static int IdUsuarioMinimo()
        {
            int idUsuario =Convert.ToInt32(usuariosAdapter.IdUsuarioMinimo());
                return idUsuario;
        }

        internal static List<Usuario> CargaComboUsuarios()
        {
             usuariosTabla = usuariosAdapter.GetData();
            List<Usuario> listaUsuarios = new List<Usuario>();
            foreach (DataSet1.UsuariosRow u in usuariosTabla)
                listaUsuarios.Add(new Usuario(u));
            return listaUsuarios;
        }

        public static DataSet1.ClientesDataTable CargaClientesUsuario(int idUsuario)
        {
            clientesTabla = clientesAdpater.ClientesUsuario(idUsuario);
            return clientesTabla;
        }

        internal static int CuentaClientesUsuario(int idUsuario)
        {
            int cuentaClientes = Convert.ToInt32(clientesAdpater.NumeroClientesUsuario(idUsuario));
            return cuentaClientes;
        }

        internal static int CuentaTodosClientes()
        {
            int numeroTodosClientes =Convert.ToInt32(clientesAdpater.CuentaTodosClientes());
            return numeroTodosClientes;
        }

        internal static object SinAsignar()
        {
            clientesTabla = clientesAdpater.ClientesSinAsignar();
            return clientesTabla;
        }

        internal static int NumClientesSinAsignar()
        {
            int numCliSin = Convert.ToInt32(clientesAdpater.NumCliSinAsignar());
            return numCliSin;
        }

        public static string TotalGlobalLineas(int idFactura)
        {
            double totGlobal = Convert.ToDouble(lineasAdapter.TotalGlobalPorIdFactura(idFactura));
            return totGlobal.ToString("0.00 €");
        }

        public static string SubTotalGlobal(int idFactura)
        {
            double subTotGlobal = Convert.ToDouble(lineasAdapter.SubtotalGlobal(idFactura));
            return subTotGlobal.ToString("0.00 €");
        }

        public static int CuentaLineas(int idFactura)
        {
            int cuentaLineas = Convert.ToInt32(lineasAdapter.NumLineas(idFactura));
            return cuentaLineas;
        }

        public static int CuentaFacturas(int idCliente)
        {
            int cuentaFacturas = Convert.ToInt32(facturasAdapter.NumFacturas(idCliente));
            return cuentaFacturas;
        }

        public static DataSet1.UsuariosDataTable UsuarioPerfil(int idUsuario)
        {
            usuarioPerfil = usuariosAdapter.UsuarioActivoPorId(idUsuario);
            //Usuario usuPerfil = new Usuario(usuReg);
            return usuarioPerfil;

        }

        static DataSet1.ClientesDataTable clientesTabla = new DataSet1.ClientesDataTable();
        static DataSet1.ClientesDataTable clienteExistente = new DataSet1.ClientesDataTable();

        public static Concepto DevuelveConcepto(int idConcepto)
        {
            DataSet1.ConceptosRow conceptoSeleccionado;
            conceptoSeleccionado = conceptosTabla.FindByIdConcepto(idConcepto);
            Concepto conceptoDevuelto = new Concepto(conceptoSeleccionado);
            return conceptoDevuelto;
        }



        public static int CuentaClientes(int idDDL)
        {
            //int cuentaClientes = Convert.ToInt32(clientesAdpater.NumeroClientes());
            int cuentaClientes = Convert.ToInt32(clientesAdpater.CuentaClientes(idDDL));
            return cuentaClientes;
        }

        public static List<Concepto> CargaComboConceptos()
        {
            List<Concepto> listaConceptos = new List<Concepto>();
            conceptosTabla = conceptosAdapter.GetData();
            foreach (DataSet1.ConceptosRow g in conceptosTabla)
                listaConceptos.Add(new Concepto(g));
            return listaConceptos;
        }

        //LINEAS
        static LineasTableAdapter lineasAdapter = new LineasTableAdapter();

        public static void ModificarUsuarioPerfil(Usuario usuEdit)
        {
            DataSet1.UsuariosRow regUsuario = usuarioPerfil.FindByIdUsuario(usuEdit.IdUsuario);
            regUsuario.Nombre = usuEdit.Nombre;
            regUsuario.Contraseña = usuEdit.Contrasenya;
            regUsuario.Email = usuEdit.Email;
            regUsuario.Pregunta = usuEdit.Pregunta;
            regUsuario.Respuesta = usuEdit.Respuesta;


            usuariosAdapter.Update(regUsuario);
            usuarioPerfil.AcceptChanges();
        }

        public static DataSet1.ConceptosDataTable ConceptoPorNombre(string nombre)
        {
            DataSet1.ConceptosDataTable conceptoRepetido = new DataSet1.ConceptosDataTable();
            conceptoRepetido = conceptosAdapter.ConceptoPorNombre(nombre);
            return conceptoRepetido;
        }

        static DataSet1.LineasDataTable lineasTabla = new DataSet1.LineasDataTable();

        public static void ModificarConcepto(Concepto concepto)
        {
            DataSet1.ConceptosRow conceptoReg = conceptosTabla.FindByIdConcepto(concepto.IdConcepto);
            conceptoReg.Nombre = concepto.Nombre;
            conceptoReg.Precio = concepto.Precio;
            conceptoReg.TipoIva = concepto.TipoIva;
            /* facturaReg.Concepto = fact.Concepto;
             facturaReg.Importe = fact.Importe.ToString();
             facturaReg.TipoIva = fact.TipoIva;
             facturaReg.IdCliente = fact.IdCliente;*/

            conceptosAdapter.Update(conceptoReg);
            conceptosTabla.AcceptChanges();

        }

        public static double TotalGlobal(int idCliente)
        {
            double totalGlobal = Convert.ToDouble(facturasAdapter.TotalGlobalFacturaPorIdFactura(idCliente));
            return totalGlobal;
        }

        internal static string NombreUsuario(int v)
        {
            string nombre = usuariosAdapter.NombreUsuario(v)[0].Nombre;
            return nombre;
        }

        public static void AddLinea(Linea linea)
        {
            DataSet1.LineasRow lineaReg = lineasTabla.NewLineasRow();

            lineaReg.IdFactura = linea.IdFactura;

            lineaReg.Concepto = linea.Concepto;
            /*
            string cant = linea.Cantidad.ToString();
            string cantSql = cant.Replace(",", ".");
            double cantF = Convert.ToDouble(cantSql);
            lineaReg.Cantidad = cantF;*/
             lineaReg.Cantidad = linea.Cantidad;
            lineaReg.Precio = linea.Precio;
            lineaReg.TipoIva = linea.TipoIva;

            lineasTabla.AddLineasRow(lineaReg);
            lineasAdapter.Update(lineaReg);
            lineasTabla.AcceptChanges();
        }

        public static string TipoIvaPorNombre(string concepto)
        {
            string tipoIva = conceptosAdapter.TipoIvaPorConcepto(concepto);
            return tipoIva;
        }

        public static string PrecioPorNombre(string concepto)
        {
            string precio = conceptosAdapter.PrecioPorConcepto(concepto).ToString();
            return precio;
        }

        public static void ModificarLinea(Linea linea)
        {
            DataSet1.LineasRow lineaReg = lineasTabla.FindByIdLinea(linea.IdLinea);
            lineaReg.IdFactura = linea.IdFactura;
            lineaReg.Concepto = linea.Concepto;
            lineaReg.Precio = linea.Precio;
            lineaReg.TipoIva = linea.TipoIva;
            lineaReg.Cantidad = linea.Cantidad;
            lineasAdapter.Update(lineaReg);
            lineasTabla.AcceptChanges();

        }

        public static void EditarPerfil(Usuario usuPerfil)
        {
            DataSet1.UsuariosRow usuAct = usuariosTabla.FindByIdUsuario(usuPerfil.IdUsuario);
            usuAct.Nombre = usuPerfil.Nombre;
            usuAct.Contraseña = usuPerfil.Contrasenya;
            usuAct.Acceso = usuPerfil.Acceso;
           // usuAct.Tipo = usuPerfil.Tipo;
            usuAct.Email = usuPerfil.Email;
            usuAct.Pregunta = usuPerfil.Pregunta;
            usuAct.Respuesta = usuPerfil.Respuesta;

            usuariosAdapter.Update(usuAct);
            usuariosTabla.AcceptChanges();

        }

        public static int CuentaFact()
        {
            int numFact = Convert.ToInt32(facturasAdapter.CuentaFacturas());
            return numFact;
        }

        public static int MaxNumero()
        {
            int num =Convert.ToInt32(facturasAdapter.MaxFactura())+1;
            return num;
        }

        public static string TipoIva(int idConcepto)
        {
            string tipoIva;
            tipoIva = conceptosAdapter.TipoIvaConceptoPorId(idConcepto).ToString();
            return tipoIva;
        }

        public static string Precio(int idConcepto)
        {
            string precio;
            precio = conceptosAdapter.PrecioConceptoPorId(idConcepto).ToString();
            return precio;
        }

        public static void AddConcepto(Concepto concepto)
        {
            DataSet1.ConceptosRow conceptoReg = conceptosTabla.NewConceptosRow();


            conceptoReg.Nombre = concepto.Nombre;
            conceptoReg.Precio = concepto.Precio;
            conceptoReg.TipoIva = concepto.TipoIva;

            conceptosTabla.AddConceptosRow(conceptoReg);
            conceptosAdapter.Update(conceptoReg);
            conceptosTabla.AcceptChanges();
        }

        internal static object CargaClientes(int idUsuario)
        {
            if (idUsuario == 0)
            {
                clientesTabla = clientesAdpater.GetData();
            }
            else
            {
                clientesTabla = clientesAdpater.ClientesUsuario(idUsuario);
            }
            return clientesTabla;
        }

        //CONCEPTOS
        static ConceptosTableAdapter conceptosAdapter = new ConceptosTableAdapter();
        static DataSet1.ConceptosDataTable conceptosTabla = new DataSet1.ConceptosDataTable();

        public static DataSet1.LineasDataTable CargaLineasFactura(int idFactura)
        {
            lineasTabla = lineasAdapter.CargaLineasFacturaPorId(idFactura);
            //lineasTodas = facturasAdapter.GetData();
            return lineasTabla;
        }

        public static void DeleteConcepto(int idConcepto)
        {
            conceptosAdapter.BorrarConceptoPorIdConcepto(idConcepto);
        }

        public static void AddUsuario(Usuario usuNuevo)
        {
            DataSet1.UsuariosRow usuReg = usuariosTabla.NewUsuariosRow();
            usuReg.Nombre = usuNuevo.Nombre;
            usuReg.Contraseña = usuNuevo.Contrasenya;
            usuReg.Acceso = usuNuevo.Acceso;
            //usuReg.Tipo = usuNuevo.Tipo;
            usuReg.Email = usuNuevo.Email;
            usuReg.Pregunta = usuNuevo.Pregunta;
            usuReg.Respuesta = usuNuevo.Respuesta;
           
            usuariosTabla.AddUsuariosRow(usuReg);
            usuariosAdapter.Update(usuReg);
            usuariosTabla.AcceptChanges();
        }

        public static bool CheckUser(string text)
        {
            bool existe = false;
            DataSet1.UsuariosDataTable usuExistente = usuariosAdapter.GetUsuarioPorNombre(text);
            if (usuExistente.Count != 0)
                existe = true;
            return existe;
        }

        public static double TotalFactura(int idFactura)
        {
            double totalFact = Convert.ToDouble(lineasAdapter.TotalFacturaPorIdFactura(idFactura));
            return totalFact;
        }



        //FACTURAS
        static FacturasTableAdapter facturasAdapter = new FacturasTableAdapter();
        static DataSet1.FacturasDataTable facturasTabla = new DataSet1.FacturasDataTable();
        static DataSet1.FacturasDataTable facturaExistente = new DataSet1.FacturasDataTable();
        static DataSet1.FacturasDataTable facturasTodas = new DataSet1.FacturasDataTable();

        public static void ModificarUsuario(Usuario usu)
        {
            DataSet1.UsuariosRow usuReg = usuariosTabla.FindByIdUsuario(usu.IdUsuario);

            usuReg.Nombre = usu.Nombre;
            usuReg.Contraseña = usu.Contrasenya;
            usuReg.Acceso = usu.Acceso;
            //usuReg.Tipo = usu.Tipo;
            usuReg.Email = usu.Email;
            usuReg.Pregunta = usu.Pregunta;
            usuReg.Respuesta = usu.Respuesta;
            

            usuariosAdapter.Update(usuReg);
            usuariosTabla.AcceptChanges();
        }

        public static Usuario DevuelveUsuario(int idUsuario)
        {
            DataSet1.UsuariosRow usuarioSel = usuariosTabla.FindByIdUsuario(idUsuario);
            //Usuario usuarioDevuelto = new Usuario(idUsuario,usuarioSel.Nombre,usuarioSel.Contraseña,usuarioSel.Acceso,usuarioSel.Tipo,usuarioSel.Email,usuarioSel.Pregunta,usuarioSel.Respuesta);
            Usuario usuarioDevuelto = new Usuario(usuarioSel);
            return usuarioDevuelto;
        }

        public static void DeleteLinea(int idLinea)
        {
            lineasAdapter.DeleteLineaPorIdLinea(idLinea);
        }

        public static DataSet1.ClientesDataTable BuscaClienteNif(string cifFinal)
        {
            clienteExistente = clientesAdpater.GetClientesPorCif(cifFinal);
            return clienteExistente;
        }

        public static Linea DevuelveLinea(int idLinea)
        {
            DataSet1.LineasRow lineaSeleccionada;
            lineaSeleccionada = lineasTabla.FindByIdLinea(idLinea);
            Linea lineaDevuelta = new Linea(lineaSeleccionada);
            return lineaDevuelta;
        }

        public static void ModificarFactura(Factura fact)
        {
            DataSet1.FacturasRow facturaReg = facturasTabla.FindByIdFactura(fact.IdFactura);
            facturaReg.Fecha = fact.Fecha;
            facturaReg.Numero = fact.Numero;
            /* facturaReg.Concepto = fact.Concepto;
             facturaReg.Importe = fact.Importe.ToString();
             facturaReg.TipoIva = fact.TipoIva;
             facturaReg.IdCliente = fact.IdCliente;*/

            facturasAdapter.Update(facturaReg);
            facturasTabla.AcceptChanges();

        }

        public static void DeleteUsuario(int idUsuario)
        {
            usuariosAdapter.DeleteUsuarioPorId(idUsuario);
        }

        public static void DeleteFactura(int idFactura)
        {
            facturasAdapter.BorrarFacturaPorId(idFactura);
        }

        public static void AddFactura(Factura fact)
        {
            DataSet1.FacturasRow facturaReg = facturasTabla.NewFacturasRow();


            facturaReg.Fecha = fact.Fecha;
            facturaReg.Numero = fact.Numero;
            /* facturaReg.Concepto = fact.Concepto;
             facturaReg.Importe = fact.Importe.ToString();
             facturaReg.TipoIva = fact.TipoIva;*/
            facturaReg.IdCliente = fact.IdCliente;

            facturasTabla.AddFacturasRow(facturaReg);
            facturasAdapter.Update(facturaReg);
            facturasTabla.AcceptChanges();
        }


        //USUARIOS
        //Cargo las tabla Usuario

        public static DataSet1.UsuariosDataTable CargaUsuarios()
        {
            usuariosTabla = usuariosAdapter.GetData();
            return usuariosTabla;
        }

        public static void DeleteFacturas(int idFactura)
        {
            throw new NotImplementedException();
        }

        public static void ModificarCliente(Cliente cliente)
        {
            DataSet1.ClientesRow regCliente = clientesTabla.FindByIdCliente(cliente.IdCliente);
            regCliente.Nombre = cliente.Nombre;
            regCliente.Cif = cliente.Cif;
            regCliente.Direccion = cliente.Direccion;
            regCliente.Ciudad = cliente.Ciudad;
            regCliente.Telefono = cliente.Telefono;
            regCliente.email = cliente.Email;
            regCliente.Persona = cliente.Persona;
            regCliente.IdUsuario = cliente.IdUsuario;
            

            clientesAdpater.Update(regCliente);
            clientesTabla.AcceptChanges();


        }

        public static Factura DevuelveFactura(int idFactura)
        {
            DataSet1.FacturasRow factReg = facturasTabla.FindByIdFactura(idFactura);
            Factura facturaDevolver = new Factura(idFactura, factReg.IdCliente, factReg.Fecha, factReg.Numero);
            return facturaDevolver;
        }





        public static void AddCliente(Cliente cliente)
        {
            DataSet1.ClientesRow regCliente = clientesTabla.NewClientesRow();
            regCliente.Nombre = cliente.Nombre;
            regCliente.Cif = cliente.Cif;
            regCliente.Direccion = cliente.Direccion;
            regCliente.Ciudad = cliente.Ciudad;
            regCliente.Telefono = cliente.Telefono;
            regCliente.email = cliente.Email;
            regCliente.Persona = cliente.Persona;
            regCliente.IdUsuario = cliente.IdUsuario;

            clientesTabla.AddClientesRow(regCliente);
            clientesAdpater.Update(regCliente);
            clientesTabla.AcceptChanges();



        }

        /*public static DataSet1.UsuariosDataTable CargaUsuariosOrdenados() 
        {
            DataSet1.UsuariosDataTable usuariosTablaOrdenados;
            usuariosTablaOrdenados = usuariosAdapter.GetUsuariosOrdenados();
            return usuariosTablaOrdenados;
        }*/

        public static int NumeroUsuarios()
        {
            int numero = Convert.ToInt32(usuariosAdapter.NumeroUsuarios());
            return numero;

        }

        public static int NumeroAdm()
        {
            int numAdm = Convert.ToInt32(usuariosAdapter.NumeroAdm());
            return numAdm;
        }



        public static void BorrarUsuario(DataSet1.UsuariosRow usuarioReg)
        {
            // DataSet1.UsuariosRow usuarioABorrar = usuariosTabla.FindByIdUsuario(idUsuario);
            usuarioReg.Delete();
            usuariosAdapter.Update(usuarioReg);

        }
        //cargo la tabla usuarioActivo
        public static DataSet1.UsuariosDataTable UsuarioActivo(string Nombre)
        {
            usuarioActivo = usuariosAdapter.GetUsuarioPorNombre(Nombre);
            return usuarioActivo;
        }

        public static void RegistrarUsuario(Usuario usuarioN)
        {
            DataSet1.UsuariosRow usuarioNuevo;
            usuarioNuevo = usuariosTabla.NewUsuariosRow();

            usuarioNuevo.Nombre = usuarioN.Nombre;
            usuarioNuevo.Contraseña = usuarioN.Contrasenya;
            //usuarioNuevo.Tipo = "Deshabilitado";
            usuarioNuevo.Acceso = 3;
            usuarioNuevo.Email = usuarioN.Email;

            usuariosTabla.AddUsuariosRow(usuarioNuevo);
            usuariosAdapter.Update(usuarioNuevo);

        }
        public static DataSet1.UsuariosRow SeleccionarUsuario(int idUsuario)
        {
            DataSet1.UsuariosRow usuarioSel = usuariosTabla.FindByIdUsuario(idUsuario);
            return usuarioSel;
        }

        public static void EditarAnyadirUsuario(Usuario usuarioEdit)
        {
            DataSet1.UsuariosRow usuarioEditado;
            if (usuarioEdit.IdUsuario > 0)
                usuarioEditado = usuariosTabla.FindByIdUsuario(usuarioEdit.IdUsuario);
            else usuarioEditado = usuariosTabla.NewUsuariosRow();

            usuarioEditado.Nombre = usuarioEdit.Nombre;
            usuarioEditado.Contraseña = usuarioEdit.Contrasenya;
            //usuarioEditado.Tipo = usuarioEdit.Tipo;
            usuarioEditado.Acceso = usuarioEdit.Acceso;
            usuarioEditado.Email = usuarioEdit.Email;

            if (usuarioEdit.IdUsuario < 0)
                usuariosTabla.AddUsuariosRow(usuarioEditado);

            usuariosAdapter.Update(usuarioEditado);

        }

        //CLIENTES

        //cargo la tabla de clientes
        public static DataSet1.ClientesDataTable CargaClientes()
        {
            clientesTabla = clientesAdpater.GetData();
            return clientesTabla;
        }

        //encuentro un cliente por su idCliente y devuelvo el registro de ese cliente
        public static DataSet1.ClientesRow ClienteSeleccionado(int idCliente)
        {

            DataSet1.ClientesRow clienteSeleccionado;
            clienteSeleccionado = clientesTabla.FindByIdCliente(idCliente);
            return clienteSeleccionado;
        }
        public static Cliente DevuelveCliente(int idCliente)
        {

            DataSet1.ClientesRow clienteSeleccionado;
            clienteSeleccionado = clientesTabla.FindByIdCliente(idCliente);
            Cliente clienteDevuelto = new Cliente(clienteSeleccionado);
            return clienteDevuelto;
        }

        public static void BorrarCliente(int idCliente)
        {

            DataSet1.ClientesRow regClienteBorrar = clientesTabla.FindByIdCliente(idCliente);
            regClienteBorrar.Delete();
            clientesAdpater.Update(regClienteBorrar);
        }
        /* public static string NombreClienteBorrar(int idCliente)
         {
             string nombreClienteBorrar;
             DataSet1.ClientesRow regClienteBorrar = clientesTabla.FindByIdCliente(idCliente);
             nombreClienteBorrar = regClienteBorrar.Nombre;
             return nombreClienteBorrar;
         }*/

        public static void EditarAnyadirCliente(Cliente clienteEdit)//recibo el cliente del detalleCliente y en un solo metodo lo edito o lo añado como nuevo
        {
            DataSet1.ClientesRow clienteEditado;//creo un registro para esos datos recibidos

            if (clienteEdit.IdCliente > 0)//entonces ya existe, voy a editar
            {
                clienteEditado = clientesTabla.FindByIdCliente(clienteEdit.IdCliente);//lo busco
            }
            else
            {
                clienteEditado = clientesTabla.NewClientesRow();//no existe y crearé uno nuevo
            }
            //en cualquier caso lo actualizo con los datos devueltos por detalleUsuarios
            clienteEditado.Nombre = clienteEdit.Nombre;
            clienteEditado.Cif = clienteEdit.Cif;
            clienteEditado.Direccion = clienteEdit.Direccion;
            clienteEditado.Ciudad = clienteEdit.Ciudad;
            clienteEditado.Telefono = clienteEdit.Telefono;
            clienteEditado.email = clienteEdit.Email;
            clienteEditado.Persona = clienteEdit.Persona;
            clientesAdpater.Update(clienteEditado);

            if (clienteEdit.IdCliente < 0)//será -1 que es nuevo usuario
                clientesTabla.AddClientesRow(clienteEditado);//lo añado

            clientesAdpater.Update(clienteEditado);//actualizo en cualquier caso, si era existente se actualiza
            //solamente y si es nuevo se añade

        }

        public static object UsuarioPorTipo(string tipo)
        {
            if (tipo != "Todos")
                usuariosTabla = usuariosAdapter.GetUsuarioPorTipo(tipo);
            else
                usuariosTabla = usuariosAdapter.GetUsuariosOrdenados();

            return usuariosTabla;
        }

        public static DataSet1.ClientesDataTable BuscaClientes(string text)
        {
            clientesTabla = clientesAdpater.ClienteBuscarPorNombre(text);
            return clientesTabla;
        }

        public static DataSet1.ClientesDataTable ClientePorNombre(string nombre)
        {
            clienteExistente = clientesAdpater.GetClientesPorNombre(nombre);
            return clienteExistente;

        }
        public static Cliente SeleccionarCliente(int idCliente)
        {
            DataSet1.ClientesRow clienteSeleccinadoReg = clientesTabla.FindByIdCliente(idCliente);
            Cliente clienteSel = new Entidades.Cliente(clienteSeleccinadoReg);
            return clienteSel;
        }

        //FACTURAS

        public static DataSet1.FacturasDataTable CargaFacturasCliente(int idCliente)
        {
            facturasTabla = facturasAdapter.GetDataByConIvaPorIdCliente(idCliente);
            facturasTodas = facturasAdapter.GetData();
            return facturasTabla;
        }

       /* public static double TotalFacturasCliente(int idCliente)
        {
            double total = Convert.ToDouble(facturasAdapter.TotalFacturasPorIdCliente(idCliente));
            return total;
        }*/

       /* public static double TotalCuotaIvaCliente(int idCliente)
        {
            double cuotasIva = Convert.ToDouble(facturasAdapter.FacturasCuotaIvaPorIdCliente(idCliente));
            return cuotasIva;
        }*/

       /* public static double TotalImporteConIva(int idCliente)
        {
            double totalMasIva = Convert.ToDouble(facturasAdapter.FacturasTotalPorIdCliente(idCliente));
            return totalMasIva;
        }*/

        public static Factura SeleccionaFactura(int idFactura)
        {
            DataSet1.FacturasRow facturaSeleccionada = facturasTabla.FindByIdFactura(idFactura);
            Factura facturaEditar = new Factura(facturaSeleccionada);
            return facturaEditar;
        }

        public static void BorraFactura(int idFactura)
        {

            facturasAdapter.BorrarFacturaPorId(idFactura);


        }
        public static Factura FacturaSeleccionada(int idFactura)
        {
            DataSet1.FacturasRow facturaSel = facturasTabla.FindByIdFactura(idFactura);
            Factura facturaDev = new Factura(facturaSel);
            return facturaDev;
        }

        /*
        public static Cliente DevuelveCliente(int idCliente)
        {

            DataSet1.ClientesRow clienteSeleccionado;
            clienteSeleccionado = clientesTabla.FindByIdCliente(idCliente);
            Cliente clienteDevuelto = new Cliente(clienteSeleccionado);
            return clienteDevuelto;
        }
        */

        public static void EditarAnyadirFactura(Factura facturaEdit, int idCliente)
        {
            DataSet1.FacturasRow facturaEditada;

            if (facturaEdit.IdFactura > 0)//factura ya existe
                                          //facturaEditada = facturasTabla.FindByIdFactura(facturaEdit.IdFactura);
                facturaEditada = facturasTodas.FindByIdFactura(facturaEdit.IdFactura);

            else  //facturaEditada = facturasTabla.NewFacturasRow();
                facturaEditada = facturasTodas.NewFacturasRow();

            facturaEditada.IdCliente = idCliente;
            facturaEditada.Fecha = facturaEdit.Fecha;
            facturaEditada.Numero = facturaEdit.Numero;
            /*facturaEditada.Concepto = facturaEdit.Concepto;
            facturaEditada.Importe = facturaEdit.Importe.ToString();
            facturaEditada.TipoIva = facturaEdit.TipoIva;*/
            facturasAdapter.Update(facturaEditada);

            if (facturaEdit.IdFactura < 0)
            {
                //facturasTabla.AddFacturasRow(facturaEditada);
                facturasTodas.AddFacturasRow(facturaEditada);
            }

            facturasAdapter.Update(facturaEditada);//hay que añadirlo a la tabla de todas las facturas


        }
        public static bool FacturaPorNumero(string numero)
        {
            facturaExistente = facturasAdapter.GetFacturasPorNumero(numero);
            if (facturaExistente.Count != 0)
                return true;

            else return false;

        }

        public static DataSet1.FacturasDataTable FacturaWebPorNumero(string numero)
        {
            DataSet1.FacturasDataTable facturaExistente = facturasAdapter.GetFacturasPorNumero(numero);
            return facturaExistente;
        }



    }

}