using System;
using System.Collections.Generic;
using System.Linq;
using PlatformService.Models;

namespace PlatformService.Data
{
  public class PlatformRepository : IPlatformRepository
  {
      private readonly AppDbContext _context;

      // Dependency Injection
      public PlatformRepository(AppDbContext context)
      {
          _context = context;
      }

      public void CreatePlatform(Platform platform)
      {
        if (platform == null)
        {
          throw new ArgumentNullException(nameof(platform));
        }

        _context.Platforms.Add(platform);
      }

      public IEnumerable<Platform> GetAllPlatforms() {
        return _context.Platforms.ToList();
      }

      public bool SaveChanges()
      {
        return (_context.SaveChanges() >= 0);
      }

      public Platform GetPlatformById(int id)
      {
        return _context.Platforms.FirstOrDefault(p => p.Id == id);
      }

  }
}