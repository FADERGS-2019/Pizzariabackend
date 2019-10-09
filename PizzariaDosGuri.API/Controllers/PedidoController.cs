using Entities;
using PizzariaDosGuri.DAL;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PizzariaDosGuri.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Pedidos")]
    public class PedidoController : ApiController
    {
        private PizzariaDataContext db = new PizzariaDataContext();

        /// <summary>
        /// Método responsável por resgatar todos os clientes
        /// </summary>
        /// <remarks>Retorna a lista de clientes ordenados por id</remarks>
        /// <response code="500">Internal Server Error.</response>
        [AllowAnonymous]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            try
            {
                using (PizzariaDataContext context = new PizzariaDataContext())
                {
                    return Ok(context.Pedidos.OrderByDescending(x => x.PedidoId).Select(item => new
                    {
                        
                        item.entrega,
                        item.pagamento,
                        item.itens
                     
                    }).ToList());
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //----------------------------------------
        /// <summary>
        /// Método responsável por salvar/atualizar os registros dos clientes. 
        /// </summary>
        /// <param name="model">Salvar o cliente</param>
        /// <remarks>Adiciona e edita os registros dos clientes.</remarks>
        /// <response code="200">Registro Alterado.</response>
        /// <response code="201">Registro Criado.</response>
        /// <response code="500">Internal Server Error.</response>
        [AllowAnonymous]
        [Route("Post")]
        public IHttpActionResult Post(Pedido model)
        {
            try
            {
                using (PizzariaDataContext context = new PizzariaDataContext())
                {


                    var clienteDb = context.Clientes.FirstOrDefault(x => x.Telefone == model.entrega.Telefone);
                    var pedidoDb = context.Pedidos.FirstOrDefault(x => x.PedidoId != model.PedidoId);
                    model.cliente = clienteDb;
              
                    
                    var isCreated = false;

                    model.Id = context.Pedidos.OrderByDescending(x => x.Id).First().Id + 1;
                    model.PedidoId = context.Pedidos.OrderByDescending(x => x.PedidoId).First().PedidoId + 1;
                    model.cliente.ClienteId = context.Clientes.OrderByDescending(x => x.ClienteId).First().ClienteId + 1;
 
                    pedidoDb = context.Pedidos.Add(model);
                  
                    isCreated = true;
                    pedidoDb.DataInclusao = DateTime.Now;
                    
                    context.SaveChanges();
                    if (isCreated)
                        return Created($"{Request.RequestUri.ToString()}/{pedidoDb.PedidoId}", pedidoDb);

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        //criar api's aqui

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
