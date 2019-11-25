using Entities;
using PizzariaDosGuri.DAL;
using System;
using System.Data.Entity;
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

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
                        item.cliente,
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

        [AllowAnonymous]
        [Route("GetNotDone")]
        public IHttpActionResult GetNotDone()
        {
            try
            {
                using (var context = new PizzariaDataContext())
                {

                    var pedidosNotDone = context.Pedidos
                    .Include(b => b.itens.Select(p => p.sabores))
                    .Where(y => !y.Status)
                    .ToList();

                    return Ok(pedidosNotDone);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [AllowAnonymous]
        [Route("Post")]
        public IHttpActionResult Post(Pedido model)
        {
            try
            {
                using (PizzariaDataContext context = new PizzariaDataContext())
                {

                    var subject = "Seu Pedido foi Confirmado!!!";
                    var body = "Seu pedido, foi recebido e já será preparado por nossos chefs!";

                    var clienteDb = context.Clientes.FirstOrDefault(x => x.Telefone == model.entrega.Telefone);
                    var pedidoDb = context.Pedidos.FirstOrDefault(x => x.PedidoId != model.PedidoId);
                    model.cliente = clienteDb;
                    var email = model.entrega.Email;

                    var isCreated = false;

                    model.Id = context.Pedidos.OrderByDescending(x => x.Id).First().Id + 1;
                    model.PedidoId = context.Pedidos.OrderByDescending(x => x.PedidoId).First().PedidoId + 1;
                    model.cliente.ClienteId = context.Clientes.OrderByDescending(x => x.ClienteId).First().ClienteId + 1;

                    pedidoDb = context.Pedidos.Add(model);
                    isCreated = true;
                    pedidoDb.DataInclusao = DateTime.Now;

                    context.SaveChanges();
                    EmailController.Execute(email, body, subject).Wait();
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

        [AllowAnonymous]
        [Route("PostDone")]
        public IHttpActionResult PostDone(Pedido model)
        {
            try
            {
                using (PizzariaDataContext context = new PizzariaDataContext())
                {
                    var subject = "Seu Pedido esta a caminho!!!";
                    var body = "Seu pedido, já foi preparado, e esta saindo para entrega!";
                    var pedidoDb = context.Pedidos.FirstOrDefault(x => x.PedidoId == model.PedidoId);
                    pedidoDb = context.Pedidos.FirstOrDefault(x => x.Id == model.Id);
                   
                    var email = model.entrega.Email;
                    var isCreated = false;

                    pedidoDb.Status = true;
                    isCreated = true;
                    pedidoDb.DataInclusao = DateTime.Now;

                    context.Entry(pedidoDb).State = EntityState.Modified;
                    context.SaveChanges();
                    EmailController.Execute(email, body, subject).Wait();
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
    }
}
