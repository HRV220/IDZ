using System.Data.Entity;
using System.Web.Mvc;
using IDZ.Models.Entities;
using System.Linq;
using System;
using IDZ.Models.DTO;
using System.Security.Claims;
using Antlr.Runtime;
using System.Data.SqlClient;
using System.Collections.Generic;

public class AuctionController : Controller
{
    private readonly idzEntities _context = new idzEntities(); // Создаём контекст базы данных

    // GET: Auction
    public ActionResult AuctionList(string sortOrder, string search)
    {
        var auctions = _context.Auctions.AsQueryable(); // Начинаем с базы данных

        // Фильтрация по запросу, если введен текст
        if (!string.IsNullOrEmpty(search))
        {
            auctions = auctions.Where(a => a.Title.Contains(search));
        }

        // Добавление сортировки
        switch (sortOrder)
        {
            case "TitleAsc":
                auctions = auctions.OrderBy(a => a.Title);
                break;
            case "TitleDesc":
                auctions = auctions.OrderByDescending(a => a.Title);
                break;
            case "PriceAsc":
                auctions = auctions.OrderBy(a => a.StartingPrice);
                break;
            case "PriceDesc":
                auctions = auctions.OrderByDescending(a => a.StartingPrice);
                break;
            case "StartTimeAsc":
                auctions = auctions.OrderBy(a => a.StartTime);
                break;
            case "StartTimeDesc":
                auctions = auctions.OrderByDescending(a => a.StartTime);
                break;
            default:
                auctions = auctions.OrderBy(a => a.Title); // Сортировка по умолчанию
                break;
        }

        // Возвращаем данные в представление
        return View(auctions.ToList());
    }


    [HttpGet]
    public ActionResult AuctionDetails(Guid aucID)
    {
        Auctions auctions = new Auctions();
        AuctionDTO auctionDTO = new AuctionDTO();
        using (var context = new idzEntities())
        {
            auctions = context.Auctions.Find(aucID);
            auctionDTO = new AuctionDTO
            {
                Title = auctions.Title,
                CreatedLogin = context.Users.Find(auctions.UserID).Login,
                Description = auctions.Description,
                StartTime = auctions.StartTime,
                EndTime = auctions.EndTime,
                StartingPrice = auctions.StartingPrice,
                BuyNowPrice = auctions.BuyNowPrice,
                MinBidStep = auctions.MinBidStep,
                CategoryName = context.Categories.Find(auctions.CategoryID).CategoryName,
            };
        }
        return View(auctionDTO);
    }

    public ActionResult AuctionBids(int id)
    {
        var bids = _context.Bids.ToList(); // Получение всех ставок из базы данных
        return View(bids);
    }

    [HttpGet]
    public ActionResult CreateAuction()
    {
        return View();
    }

    [HttpPost]
    public ActionResult CreateAuction(AuctionDTO newAuction)
    {
        if (ModelState.IsValid)
        {
            using (var context = new idzEntities())
            {
                Auctions auction = new Auctions
                {
                    AuctionID = Guid.NewGuid(),
                    Title = newAuction.Title,
                    Description = newAuction.Description,
                    StartTime = newAuction.StartTime,
                    EndTime = newAuction.EndTime,
                    StartingPrice = newAuction.StartingPrice,
                    BuyNowPrice = newAuction.BuyNowPrice,
                    MinBidStep = newAuction.MinBidStep,
                    CreateDate = DateTime.Now,
                    CategoryID = context.Categories.FirstOrDefault(c => c.CategoryName == newAuction.CategoryName).CategoryID,
                    UserID = Guid.Parse("a6dfeee7-d6fa-4c66-9f49-10b0ceaddfd8"/*((ClaimsIdentity)User.Identity)?.FindFirst(ClaimTypes.NameIdentifier)?.Value*/)

                };
                context.Auctions.Add(auction);
                context.SaveChanges();
            }
            return RedirectToAction("AuctionList");
        }
        return View(newAuction);
    }

}
