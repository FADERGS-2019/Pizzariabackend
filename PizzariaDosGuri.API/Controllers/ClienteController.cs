using Entities;
using PizzariaDosGuri.DAL;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PizzariaDosGuri.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Clientes")]
    public class ClienteController : ApiController
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
                    return Ok(context.Clientes.OrderByDescending(x => x.ClienteId).Select(item => new
                    {
                        clienteId = item.ClienteId,
                        item.Nome,
                        item.CPF,
                        item.Endereco,
                        item.Telefone,
                        item.Email,
                        item.UltimaCompra,
                        item.DataInclusao,
                        item.DataAlteracao,
                        item.DataExclusao,
                        item.Ativo,

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
        public IHttpActionResult Post(Cliente model)
        {
             try
            {
            using (PizzariaDataContext context = new PizzariaDataContext())
            {
                var clienteDb = context.Clientes.FirstOrDefault(x => x.CPF == model.CPF);
                var isCreated = false;

                if (clienteDb == null)
                {
                    model.Id = context.Clientes.OrderByDescending(x => x.Id).First().Id + 1; 
                    model.ClienteId = context.Clientes.OrderByDescending(x => x.ClienteId).First().ClienteId +1;
                    clienteDb = context.Clientes.Add(model);
                    isCreated = true;
                    clienteDb.DataInclusao = DateTime.Now;
                    clienteDb.UltimaCompra = clienteDb.DataInclusao;
                }
                else
                {
                    clienteDb.DataAlteracao = DateTime.Now;
                    clienteDb.UltimaCompra = DateTime.Now;
                }

                context.SaveChanges();

                if (isCreated)
                    return Created($"{Request.RequestUri.ToString()}/{clienteDb.ClienteId}", clienteDb);

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
