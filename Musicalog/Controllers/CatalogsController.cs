using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CatalogServiceClient = Musicalog.CatalogServiceClient.CatalogServiceClient;
using Musicalog.CatalogServiceClient;

namespace Musicalog.Controllers
{
	public class CatalogsController : Controller
	{
		//private MusicalogEntities1 db = new MusicalogEntities1();

		private Musicalog.CatalogServiceClient.CatalogServiceClient _catalogClient;

		// GET: Catalogs
		public CatalogsController()
		{
			this._catalogClient = new CatalogServiceClient.CatalogServiceClient();
		}

		public async Task<ActionResult> Index()
		{
			return View(_catalogClient.GetAlbumCatalog().ToList());
		}

		// GET: Catalogs/Details/5
		public async Task<ActionResult> Details(int id)
		{
			if (id < 0)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Album album = _catalogClient.GetAlbumRecord(id);
			if (album == null)
			{
				return HttpNotFound();
			}

			return View(album);
		}

		// GET: Catalogs/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Catalogs/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "AlbumID,AlbumName,Artist,Type,Stock")] Album album)
		{
			if (ModelState.IsValid)
			{

				_catalogClient.AddAlbumRecord(album);

				return RedirectToAction("Index");
			}

			return View(new Album());
		}

		// GET: Catalogs/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
			if (id < 0)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Album album = _catalogClient.GetAlbumRecord(id);
			if (album == null)
			{
				return HttpNotFound();
			}

			return View(album);
		}

		// POST: Catalogs/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "AlbumID,AlbumName,Artist,Type,Stock")] Album album)
		{
			if (ModelState.IsValid)
			{
				try
				{
					_catalogClient.UpdateAlbum(album);
				}
				catch (Exception ex)
				{

					throw ex;
				}
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");

		}

		// GET: Catalogs/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
			if (id < 0)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Album album = _catalogClient.GetAlbumRecord(id);
			if (album == null)
			{
				return HttpNotFound();
			}
			
			return View(album);
		}

		// POST: Catalogs/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			string response = _catalogClient.DeleteAlbum(id);
			if (response == null)
			{
				return HttpNotFound();
			}
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				//db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
