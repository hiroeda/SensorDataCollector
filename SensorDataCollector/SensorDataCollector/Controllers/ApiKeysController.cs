using Microsoft.AspNet.Identity;
using SensorDataCollector.Models;
using SensorDataCollector.Services;
using SensorDataCollector.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SensorDataCollector.Controllers
{
    [Authorize]
    public class ApiKeysController : BaseController
    {
        /// <summary>
        /// 一覧画面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var service = new ApiKeyService(db);
            var loginUserId = User.Identity.GetUserId();

            return View(service.GetMyKeys(loginUserId));
        }

        /// <summary>
        /// 詳細画面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var service = new SensorDataService(db);
            var loginUserId = User.Identity.GetUserId();
            return View(service.GetMyDatas(loginUserId, id));
        }

        /// <summary>
        /// 追加画面(GET)
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 追加画面(POST)
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] ApiKey apiKey)
        {
            // データ作成
            var service = new ApiKeyService(db);
            var loginUserId = User.Identity.GetUserId();
            var key = CipherUtil.CreateApiKey(ApiKeyService.KEY_LENGTH);
            apiKey = service.Create(loginUserId, apiKey.Name, key);

            service.Add(apiKey);

            TempData.Notice(string.Format("キーは[{0}]です。再表示できないためご注意ください。", key));
            return RedirectToAction("Index");
        }

        // GET: ApiKeys/Edit/5
        public ActionResult Edit(int? id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //// データ取得
            //var service = new ApiKeyService(db);
            //var loginUserId = User.Identity.GetUserId();
            //var apiKey = service.GetOne(loginUserId, id.Value);

            //if (apiKey == null)
            //{
            //    return HttpNotFound();
            //}

            //return View(apiKey);
        }

        // POST: ApiKeys/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApiId,Name")] ApiKey apiKey)
        {
            throw new NotImplementedException();
            //if (ModelState.IsValid)
            //{
            //    db.Entry(apiKey).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(apiKey);
        }

        // GET: ApiKeys/Delete/5
        public ActionResult Delete(int? id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ApiKey apiKey = db.ApiKeys.Find(id);
            //if (apiKey == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(apiKey);
        }

        // POST: ApiKeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            throw new NotImplementedException();

            //ApiKey apiKey = db.ApiKeys.Find(id);
            //db.ApiKeys.Remove(apiKey);
            //db.SaveChanges();
            //return RedirectToAction("Index");
        }

    }
}