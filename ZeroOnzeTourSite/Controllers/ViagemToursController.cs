using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using ZeroOnzeTour.DB;
using ZeroOnzeTour.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ZeroOnzeTourSite.Controllers
{
    [Authorize]
    public class ViagemToursController : Controller
    {
        private readonly MySqlContext _context;

        public ViagemToursController(MySqlContext context)
        {
            _context = context;
        }

        // GET: ViagemTour
        public async Task<IActionResult> Index()
        {

            try
            {
                var viagemTour = await _context.ViagemTour.ToListAsync();
                return View(viagemTour);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET: ViagemTour/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagemTour = await _context.ViagemTour
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viagemTour == null)
            {
                return NotFound();
            }

            return View(viagemTour);
        }

        // GET: ViagemTour/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ViagemTour/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Tutilo,SubTitulo,Incluso,NaoIncluso,FraseFinal,Data,Destaque,Ordem,FraseDestaque,Pais,Cidade,DataViagem,Valor,Descricao,ObsInvestimento,ValorPrincipal,DescricaoRoteiro,Ativo")] ViagemTour viagemTour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viagemTour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viagemTour);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("id,Tutilo,SubTitulo,Incluso,NaoIncluso,FraseFinal,Data,Destaque,Ordem,FraseDestaque,Pais,Cidade,DataViagem,Valor,Descricao,ObsInvestimento,ValorPrincipal,DescricaoRoteiro,Ativo")] ViagemTour viagemTour)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(viagemTour);
        //        await _context.SaveChangesAsync();

        //        if (ModelState.IsValid)
        //        {
        //            //if (file != null && file.Length > 0)
        //            //{
        //            //    var imageName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //            //    using (var image = Image.Load(file.OpenReadStream()))
        //            //    {
        //            //        image.Mutate(x => x.Resize(new ResizeOptions
        //            //        {
        //            //            Size = new Size(800, 600),
        //            //            Mode = ResizeMode.Max
        //            //        }));
        //            //        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/uploads", imageName);
        //            //        using (var stream = new FileStream(imagePath, FileMode.Create))
        //            //        {
        //            //            image.Save(stream, new JpegEncoder());
        //            //        }
        //            //    }
        //            //    imagem.Foto = "uploads/" + imageName;
        //            //}

        //            _context.Add(imagem);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }

        //    return View(viagemTour);
        //}

        // GET: ViagemTour/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagemTour = await _context.ViagemTour.FindAsync(id);
            if (viagemTour == null)
            {
                return NotFound();
            }
            return View(viagemTour);
        }

        // POST: ViagemTour/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("id,Tutilo,SubTitulo,Incluso,NaoIncluso,FraseFinal,Data,Destaque,Ordem,FraseDestaque,Pais,Cidade,DataViagem,Valor,Descricao,ObsInvestimento,ValorPrincipal,DescricaoRoteiro,Ativo")] ViagemTour viagemTour)
        {
            if (Id != 0)
            {
                viagemTour.Id = Id;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viagemTour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViagemTourExists(viagemTour.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viagemTour);
        }

        // GET: ViagemTour/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagemTour = await _context.ViagemTour
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viagemTour == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: ViagemTour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viagemTour = await _context.ViagemTour.FindAsync(id);
            _context.ViagemTour.Remove(viagemTour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViagemTourExists(int id)
        {
            return _context.ViagemTour.Any(e => e.Id == id);
        }
    }
}
