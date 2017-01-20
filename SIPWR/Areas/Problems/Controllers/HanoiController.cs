using SIPWR.Models;
using SIPWR.ViewServices;
using System.Web.Mvc;
using System.Linq;
using SIPWR.Hanoi;
using System;

namespace SIPWR.Areas.Problems.Controllers
{
    public class HanoiController : Controller
    {
        public ActionResult Index()
        {
            var enumService = new EnumService();

            var model = new HanoiViewModel();
            model.HanoiAlgorithms = enumService.GetHanoiAlgorithmTypes();
            model.SelectedPosition = model.HanoiAlgorithms.First().Text;

            return View(model);
        }

        public ActionResult Result(HanoiViewModel model)
        {
            if (!ModelState.IsValid ||
                model.TowerNumber < 0 ||
                model.DiscNumber < 0 ||
                model.SelectedTower < 0 ||
                model.SelectedTower > model.TowerNumber)
            {
                throw new Exception();
            }

            var type = (HanoiAlgorithm)Enum.Parse(
                typeof(HanoiAlgorithm),
                model.SelectedPosition);

            var algorithm = HanoiFactory.Get(
                type,
                model.TowerNumber,
                model.DiscNumber);

            var expectedResult = HanoiHelper.ResultGenerator(
                model.TowerNumber,
                model.DiscNumber,
                model.SelectedTower);

            algorithm.Execute(expectedResult);

            var result = new HanoiResultViewModel()
            {
                DiscNumber = model.DiscNumber,
                TowerNumber = model.TowerNumber,
                SelectedPosition = expectedResult,
                Result = algorithm.GetResult()
            };

            return View(result);
        }
    }
}