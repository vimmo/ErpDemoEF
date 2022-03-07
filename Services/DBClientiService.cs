using ErpDemoEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDemoEF.Services
{
    public interface IDBClientiService
    {
        public IEnumerable<Clienti> GetClienti();
        public Clienti GetClienti(int id);
        public Task<Clienti> PostCliente(Clienti cliente);
        public Task<Clienti> PutCliente(Clienti cliente);
        public Clienti FindCliente(int id);
        public Task DeleteCliente(Clienti cliente);
    }
    public class DBClientiService : IDBClientiService
    {
        private readonly ErpDemoContext _context;
        public DBClientiService()
        {
            _context = new ErpDemoContext();
        }
        public DBClientiService(ErpDemoContext context)
        {
            _context = context;
        }
        public IEnumerable<Clienti> GetClienti()
        {
            return _context.Clienti;
        }

        public Clienti GetClienti(int id)
        {
            return _context.Clienti.Where(c => c.Id == id).FirstOrDefault();
        }
        public async Task<Clienti> PostCliente(Clienti cliente)
        {
            _context.Clienti.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }
        public async Task<Clienti> PutCliente(Clienti cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return cliente;
        }
        public Clienti FindCliente(int id)
        {
            var cliente = _context.Clienti.Find(id);

            return cliente;
        }
        public async Task DeleteCliente(Clienti cliente)
        {
            _context.Clienti.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
