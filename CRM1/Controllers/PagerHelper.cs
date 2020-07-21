using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Web.Controllers
{
    /// <summary>
    /// 分页类
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class PageHelper<T> : List<T>
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 每页记录条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 通过构造函数分页//调用代码 PageHelper（T） page = new PageHelper（T）(list, curPage, pageSize);
        /// </summary>
        /// <param name="list">数据源</param>
        /// <param name="curPage">当前页码（自动不小于1，不大于总页数）</param>
        /// <param name="pageSize">每页显示数据量（0表示不分页；自动不小于1，不大于200）</param>
        public PageHelper(List<T> list, int curPage, int pageSize)
        {
            CurrentPage = curPage;
            PageSize = pageSize;
                TotalCount = list.Count;
            if (PageSize > 0)
            {
                if (PageSize > 200)//每页显示数据量，自动不大于200
                {
                    PageSize = 200;
                }
                PageCount = (int)Math.Ceiling(TotalCount / (double)PageSize);
                if (CurrentPage < 1)  //当前页码，自动不小于1
                {
                    CurrentPage = 1;
                }
                if (CurrentPage > PageCount) //当前页码，自动不大于总页数
                {
                    CurrentPage = PageCount;
                }
                AddRange(list.Skip((CurrentPage - 1) * PageSize).Take(PageSize));
            }
            else
            {
                PageSize = 0;
                PageCount = 0;
                CurrentPage = 0;
                AddRange(list);
            }
        }
        /// <summary>
        /// 是否有上一页或首页
        /// </summary>
        public bool HasPrevious { get { return CurrentPage > 1; } }
        /// <summary>
        /// 是否有下一页或尾页
        /// </summary>
        public bool HasNext { get { return CurrentPage < PageCount; } }

        /// <summary>
        /// 
        /// </summary>
        public string PagerHtmlA
        {
            get
            {
                string strHtml = string.Empty;
                strHtml += @"共　<span class='keypoint'>" + TotalCount + "</span>　条记录 每页　<span class='keypoint'>" + PageSize + "</span>　条 第　<span class='keypoint'>" + CurrentPage + "</span>　页/共　<span class='keypoint'>" + PageCount + "</span>　页　";
                if (HasPrevious)
                {
                    strHtml += "<a href=javascript:pagerSubmit(1)>首页</a>　";
                    strHtml += "<a href=javascript:pagerSubmit(" + (CurrentPage - 1) + ")>上一页</a>　";
                }
                else
                {
                    strHtml += "首页　上一页　";
                }
                if (HasNext)
                {

                    strHtml += "<a href=javascript:pagerSubmit(" + (CurrentPage + 1) + ")>下一页</a>　";
                    strHtml += "<a href=javascript:pagerSubmit(" + PageCount + ")>尾页</a>";
                }
                else
                {
                    strHtml += "下一页　尾页";
                }
                return strHtml;
            }
        }
    }
}