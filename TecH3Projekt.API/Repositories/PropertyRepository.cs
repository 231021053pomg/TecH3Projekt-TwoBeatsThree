using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Database;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly TecH3ProjectDbContext _context;

        public PropertyRepository(TecH3ProjectDbContext context)
        {
            _context = context;
        }


        //GETALL
        public async Task<List<Property>> GetAll()
        {
            return await _context.Property
                .Where(a => a.DeletedAt == null)
                .ToListAsync();
        }

        //GETBYID
        public async Task<Property> GetById(int id)
        {
            return await _context.Property
                .Where(a => a.DeletedAt == null)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        //CREATE
        public async Task<Property> Create(Property property)
        {
            property.CreatedAt = DateTime.Now;
            _context.Property.Add(property);
            await _context.SaveChangesAsync();
            return property;
        }

        //UPDATE
        public async Task<Property> Update(int id, Property property)
        {
            var editProperty = await _context.Property.FirstOrDefaultAsync(a => a.Id == id);
            if (editProperty != null)
            {
                // tilføj rettelses tiden til elementet, så vi kan tracke seneste ændring

                editProperty.UpdatedAt = DateTime.Now;
                editProperty.PropertyName = property.PropertyName; //??


                _context.Property.Update(editProperty);
                await _context.SaveChangesAsync();
            }
            return editProperty;
        }

        //DELETE
        public async Task<Property> Delete(int id)
        {
            var property = await _context.Property.FirstOrDefaultAsync(a => a.Id == id);
            if (property != null)
            {
                property.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return property;
        }
    }
}
