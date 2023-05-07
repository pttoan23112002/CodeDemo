using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Entitites;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Demo.Models;

namespace Demo.Controllers
{
    public class HocSinhController : Controller
    {
        private readonly IHocSinhService hocsinhService;
        private readonly IMapper mapper;

        public HocSinhController(IHocSinhService hocsinhService, IMapper mapper)
        {
            this.hocsinhService = hocsinhService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(hocsinhService.GetHocSinhs());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            HocSinhViewModel data = new HocSinhViewModel();
            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI HỌC SINH" : "CẬP NHẬT THÔNG TIN HỌC SINH";

            if (id != 0)
            {
                HocSinh res = hocsinhService.GetHocSinh(id);
                data = mapper.Map<HocSinhViewModel>(res);
                if (data == null)
                {
                    return NotFound();
                }
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, HocSinhViewModel data)
        {
            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI HỌC SINH" : "CẬP NHẬT THÔNG TIN HỌC SINH";

            if (ModelState.IsValid)
            {
                try
                {
                    HocSinh res = mapper.Map<HocSinh>(data);
                    if (id != 0)
                    {
                        hocsinhService.UpdateHocSinh(res);
                    }
                    else
                    {
                        hocsinhService.InsertHocSinh(res);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction("Index", "HocSinh");
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            HocSinh res = hocsinhService.GetHocSinh(id);
            hocsinhService.DeleteHocSinh(res);

            return RedirectToAction("Index", "HocSinh");
        }
    }
}
