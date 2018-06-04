using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Comus.Domain.Context;
using Comus.Domain.DataAccess.Interfaces;
using Comus.Domain.Models;
using Comus.Web.Models;

namespace Comus.Web.Controllers
{
    public class ClientRequestController : BaseApiController
    {
        public ClientRequestController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        // GET: api/ClientRequest
        public IEnumerable<ClientRequestViewModel> GetClientRequests()
        {
            var clientRequests = UnitOfWork.Repository<ClientRequest>()
                .Get(orderBy: o => o.OrderBy(p => p.Person.LastName)
                        .ThenBy(p => p.Person.FirstName),
                    includeProperties: "Person, ClientSource, ProductType, ClientRequestStatus");

            var clientRequestViewModels = Mapper.Map<IEnumerable<ClientRequest>, IEnumerable<ClientRequestViewModel>>(clientRequests);

            return clientRequestViewModels;
        }

        // GET: api/ClientRequest
        public ListViewModel<ClientRequestViewModel> GetClientRequests(int page, int pageSize = 10)
        {
            var clientRequestsList = UnitOfWork.Repository<ClientRequest>()
                .GetQ(
                    orderBy: o => o.OrderBy(p => p.Person.LastName)
                        .ThenBy(p => p.Person.FirstName),
                    includeProperties: "Person, ClientSource, ProductType, ClientRequestStatus");

            var clientRequests = clientRequestsList
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var clientRequestViewModels = Mapper.Map<IEnumerable<ClientRequest>, IEnumerable<ClientRequestViewModel>>(clientRequests);
            var viewModel = new ListViewModel<ClientRequestViewModel>
            {
                Items = clientRequestViewModels,
                ItemsCount = clientRequestsList.Count(),
                PagesCount = (int)Math.Ceiling((double)clientRequestsList.Count() / pageSize),
                SelectedPage = page
            };

            return viewModel;
        }

        // GET: api/Client/5
        [ResponseType(typeof(ClientRequest))]
        public IHttpActionResult GetClientRequests(int id)
        {
            var clientRequestViewModel = new ClientRequestViewModel();

            if (id != 0)
            {
                var clientRequest = UnitOfWork.Repository<ClientRequest>()
                    .Get(x => x.ClientRequestId == id, includeProperties: "Person, ClientSource, ProductType, ClientRequestStatus")
                    .SingleOrDefault();
                if (clientRequest == null)
                {
                    return NotFound();
                }

                clientRequestViewModel = Mapper.Map<ClientRequest, ClientRequestViewModel>(clientRequest);
            }

            //var clientSources = UnitOfWork.Repository<ClientSource>().Get().ToList();
            //clientRequestViewModel.ClientSources = Mapper.Map<List<ClientSource>, List<ClientSourceViewModel>>(clientSources);

            //var productTypes = UnitOfWork.Repository<ProductType>().Get().ToList();
            //clientViewModel.ProductTypes = Mapper.Map<List<ProductType>, List<ProductTypeViewModel>>(productTypes);

            //var clientStatuses = UnitOfWork.Repository<ClientStatus>().Get().ToList();
            //clientViewModel.ClientStatuses = Mapper.Map<List<ClientStatus>, List<ClientStatusViewModel>>(clientStatuses);

            //var employees = UnitOfWork.Repository<Employee>().Get(includeProperties: "Person").ToList();
            //clientViewModel.Employees = Mapper.Map<List<Employee>, List<EmployeeViewModel>>(employees);

            return Ok(clientRequestViewModel);
        }

        // PUT: api/ClientRequest/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClientRequest(ClientRequestViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientRequest = UnitOfWork.Repository<ClientRequest>()
                .Get(x => x.ClientRequestId == viewModel.ClientRequestId)
                .SingleOrDefault();
            if (clientRequest == null)
            {
                return BadRequest();
            }

            Mapper.Map<ClientRequestViewModel, ClientRequest>(viewModel, clientRequest);
            clientRequest.Person.UpdatedAt = DateTime.Now;
            clientRequest.UpdatedAt = DateTime.Now;

            UnitOfWork.Repository<ClientRequest>().Update(clientRequest);

            try
            {
                UnitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientRequestExists(viewModel.ClientRequestId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ClientRequest
        [ResponseType(typeof(ClientRequest))]
        public IHttpActionResult PostClientRequest(ClientRequestViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientRequest = Mapper.Map<ClientRequestViewModel, ClientRequest>(viewModel);
            clientRequest.Person.CreatedAt = DateTime.Now;
            clientRequest.Person.Employees = null;
            clientRequest.CreatedAt = DateTime.Now;          
            
            UnitOfWork.Repository<ClientRequest>().Insert(clientRequest);
            UnitOfWork.Save();

            return Ok();
        }

        // DELETE: api/ClientRequest/5
        [ResponseType(typeof(ClientRequest))]
        public IHttpActionResult DeleteClientRequest(int id)
        {
            ClientRequest clientRequest = UnitOfWork.Repository<ClientRequest>().GetById(id);
            if (clientRequest == null)
            {
                return NotFound();
            }

            UnitOfWork.Repository<ClientRequest>().Delete(clientRequest);
            UnitOfWork.Save();

            return Ok(clientRequest);
        }

        private bool ClientRequestExists(int id)
        {
            return UnitOfWork.Repository<ClientRequest>().GetQ().Count(e => e.ClientRequestId == id) > 0;
        }
    }
}