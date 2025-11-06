using Datos.DTOs_Stock;
using Datos.Od_Stock;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Logica_Clientes
{
    public class LogicClientes
    {
        private readonly Od_AltaCliente odAlta = new Od_AltaCliente();
        private readonly Od_ModificarCliente odMod = new Od_ModificarCliente();
        private readonly Od_EliminarCliente odDel = new Od_EliminarCliente();
        private readonly Od_ListarClientes odList = new Od_ListarClientes();

        // Alta de cliente
        public BusinessResult CrearCliente(ClienteDTO cliente)
        {
            var res = new BusinessResult();
            if (cliente == null)
            {
                res.AddError("Datos del cliente inválidos.");
                return res;
            }

            if (string.IsNullOrWhiteSpace(cliente.RazonSocial))
                res.AddError("La razón social es obligatoria.");
            if (string.IsNullOrWhiteSpace(cliente.Email))
                res.AddError("El email es obligatorio.");
            if (cliente.LimiteCredito < 0)
                res.AddError("El límite de crédito no puede ser negativo.");

            if (!res.Success) return res;

            try
            {
                bool ok = odAlta.AltaCliente(cliente);
                if (!ok) res.AddError("No se pudo registrar el cliente en la base de datos.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error creando cliente: " + ex.Message);
                return res;
            }
        }

        // Modificación de cliente
        public BusinessResult ModificarCliente(ClienteModificarDTO cliente)
        {
            var res = new BusinessResult();
            if (cliente == null)
            {
                res.AddError("Datos del cliente inválidos.");
                return res;
            }

            if (cliente.IdCliente <= 0)
                res.AddError("El ID del cliente no es válido.");
            if (string.IsNullOrWhiteSpace(cliente.RazonSocial))
                res.AddError("La razón social es obligatoria.");
            if (string.IsNullOrWhiteSpace(cliente.Email))
                res.AddError("El email es obligatorio.");
            if (cliente.LimiteCredito < 0)
                res.AddError("El límite de crédito no puede ser negativo.");

            if (!res.Success) return res;

            try
            {
                bool ok = odMod.ModificarCliente(cliente);
                if (!ok) res.AddError("No se pudo modificar el cliente.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error modificando cliente: " + ex.Message);
                return res;
            }
        }

        // Baja lógica o eliminación
        public BusinessResult EliminarCliente(int idCliente)
        {
            var res = new BusinessResult();
            if (idCliente <= 0)
            {
                res.AddError("ID de cliente inválido.");
                return res;
            }

            try
            {
                var dto = new ClienteEliminarDTO { IdCliente = idCliente };
                bool ok = odDel.EliminarCliente(dto);
                if (!ok) res.AddError("No se pudo eliminar el cliente.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error eliminando cliente: " + ex.Message);
                return res;
            }
        }

        // Listar clientes (para ABM o búsquedas)
        public BusinessResult<List<ClienteListadoDTO>> ListarClientes()
        {
            var res = new BusinessResult<List<ClienteListadoDTO>>();
            try
            {
                res.Data = odList.ListarClientes();
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error listando clientes: " + ex.Message);
                return res;
            }
        }
    }
}