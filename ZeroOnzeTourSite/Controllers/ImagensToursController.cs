﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;
using System;
using ZeroOnzeTour.DB;
using ZeroOnzeTour.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ZeroOnzeTourSite.Controllers
{
    [Authorize]
    public class ImagensToursController : Controller
    {
        private readonly MySqlContext _context;
        private string _filePath;
        IWebHostEnvironment _webHostEnvironment;
        public ImagensToursController(MySqlContext context, IWebHostEnvironment env)
        {
            _context = context;
            _filePath = env.WebRootPath;
        }

        // GET: ImagensTour
        public async Task<IActionResult> Index(int id)
        {
            try
            {
                var imagensTour = await _context.ImagensTour.Where(m => m.IdViagem == id).ToListAsync();
   
                if (imagensTour.Count() == 0)
                {
                    return RedirectToAction("Create", new { id = id });
                }

                return View(imagensTour);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        //private string ProcessaUploadedFile(ImagensTour model)
        //{
        //    string nomeArquivoImagem = null;
        //    if (model.PalestranteFoto != null)
        //    {
        //        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
        //        nomeArquivoImagem = Guid.NewGuid().ToString() + "_" + model.PalestranteFoto.FileName;
        //        string filePath = Path.Combine(uploadsFolder, nomeArquivoImagem);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.PalestranteFoto.CopyTo(fileStream);
        //        }
        //    }
        //    return nomeArquivoImagem;
        //}

        // GET: ImagensTour/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagensTour = await _context.ImagensTour
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imagensTour == null)
            {
                return NotFound();
            }

            return View(imagensTour);
        }


        // GET: ImagensTour/Create
        public IActionResult Create(int id)
        {
            var img = new ImagensTour();
            img.IdViagem = id;
            ViewBag.IdViagem = id;
            return View(img);
        }

        // POST: ImagensTour/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdViagem,Nome,Descricao,Caminho,TipoImagem,Ordem,Ativo")] ImagensTour imagensTour, IFormFile anexo)
        {
            if (ModelState.IsValid)
            {
                if (!ValidaImagem(anexo))
                    return BadRequest(ModelState);

                var nome = SalvarAquivo(anexo);
                if (nome != null)
                {
                    imagensTour.Foto = nome;
                }


                _context.Add(imagensTour);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = imagensTour.IdViagem });
            }
            return View(imagensTour);
        }

        private string SalvarAquivo(IFormFile arquivoImagem)
        {
            try
            {


                var nome = Guid.NewGuid().ToString() + arquivoImagem.FileName;
                var filePath = _filePath + "\\fotos";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                using (var stream = System.IO.File.Create(filePath + "\\" + nome))
                {
                    arquivoImagem.CopyToAsync(stream);
                }
                return nome;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private bool ValidaImagem(IFormFile arquivoImagem)
        {
            switch (arquivoImagem.ContentType)
            {
                case "image/jpeg":
                    return true;
                case "image/bmp":
                    return true;
                case "image/gif":
                    return true;
                case "image/png":
                    return true;
                default:
                    return false;
                    break;
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagensTour = await _context.ImagensTour.FindAsync(id);
            if (imagensTour == null)
            {
                return NotFound();
            }
            return View(imagensTour);
        }
        // GET: ImagensTour/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdViagem,Nome,Descricao,Caminho,TipoImagem,Ordem,Ativo")] ImagensTour imagensTour, IFormFile anexo)
        {
            if (id != imagensTour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (anexo != null && anexo.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await anexo.CopyToAsync(stream);
                            //imagensTour.Imagem = stream.ToArray();
                        }
                    }

                    _context.Update(imagensTour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagensTourExists(imagensTour.Id))
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
            return View(imagensTour);
        }


        // GET: ImagensTour/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagensTour = await _context.ImagensTour
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imagensTour == null)
            {
                return NotFound();
            }

            return View(imagensTour);
        }

        // POST: ImagensTour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imagensTour = await _context.ImagensTour.FindAsync(id);
            _context.ImagensTour.Remove(imagensTour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagensTourExists(int id)
        {
            return _context.ImagensTour.Any(e => e.Id == id);
        }
    }
}
