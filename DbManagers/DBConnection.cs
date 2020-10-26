using GoingToWorkApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoingToWorkApp.DbManagers
{
    public class DBConnection
    {
        public DBConnection()
        {
        }

        /// <summary>
        /// 社員テーブルから名前とパスワードで検索
        /// </summary>
        /// <param name="name">名前</param>
        /// <param name="pass">パスワード</param>
        /// <returns></returns>
        public IEnumerable<Emp> SelectEmp(string name, int pass)
        {
            using (var db = new GoingToWorkAppContext())
            {
                //名前とパスワードで検索
                var selectName = db.Emp.Where(x => x.EmpName.Equals(name)).ToList();
                var selectPass = selectName.Where(x => x.EmpPassword.Equals(pass)).ToList();

                //名前、パスワードどちらかが検索できなかったら処理を抜ける
                if (!selectName.Count.Equals(1))
                {
                    return selectName.AsEnumerable<Emp>();
                }
                if (!selectPass.Count.Equals(1))
                {
                    return selectPass.AsEnumerable<Emp>();
                }

                var selectEmp = db.Emp.Where(x => x.EmpName.Equals(name))
                                       .Where(x => x.EmpPassword.Equals(pass))
                                        .ToList();

                return selectEmp.AsEnumerable<Emp>();
            }
        }

        /// <summary>
        /// 勤務日テーブルの社員の名前を取得
        /// </summary>
        /// <param name="empName">登録済の名前</param>
        /// <returns></returns>
        public IEnumerable<WorkDate> GetWorkDateName(string empName)
        {
            using (var db = new GoingToWorkAppContext())
            {
                var emp = db.WorkDate.Where(x => x.EmpName.Equals(empName)).ToList();

                if (emp.Count.Equals(0))
                {
                    IEnumerable<WorkDate> nullEmp = null;
                    return nullEmp;
                }

                return emp.AsEnumerable<WorkDate>();
            }

        }


        /// <summary>
        ///  現在勤務中の従業員を検索
        /// </summary>
        /// <param name="empName">登録済みの名前</param>
        /// <param name="empPass">登録済みのパスワード</param>
        /// <returns></returns>
        public bool IsNowGoingToWork(string empName, int empPass)
        {
            using (var db = new GoingToWorkAppContext())
            {
                var selectEmp = this.SelectEmp(empName, empPass);
                //var selectName = db.Emp.Where(x => x.EmpName == empName).ToList();
                //var selectNameAndPass = selectEmp.Where(x => x.EmpPassword.Equals(empPass)).ToList();

                var isNowGoingEmp = selectEmp.Where(x => x.IsGoingToWork == true).ToList();


                if (isNowGoingEmp.Count.Equals(0))
                {
                    //出勤していない
                    return false;
                }
                else
                {
                    //現在出勤中
                    return true;
                }
            }
        }


        /// <summary>
        /// 出勤時間の記録
        /// </summary>
        /// <param name="empName">名前</param>
        /// <param name="empPass">パスワード</param>
        public void WorkStartInsert(string empName, int empPass)
        {
            using (var db = new GoingToWorkAppContext())
            {
                var selectEmp = this.SelectEmp(empName, empPass);

                if (selectEmp.Count().Equals(0))
                {
                    MessageBox.Show("出勤できませんでした。",
                                     "出勤エラー",
                                      MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                    return;
                }

                //出勤時間の記録
                db.WorkDate.Add(new WorkDate()
                {
                    EmpName = empName,
                    WorkStart = DateTime.Now,
                });

                //出勤した従業員の出勤中フラグを立てる
                var emp = db.Emp.Where(x => x.EmpName.Equals(empName)).ToList();
                emp.Select(x => x.IsGoingToWork = true).ToList();

                db.SaveChanges();
            }
        }



        /// <summary>
        /// 休憩開始時間を記録
        /// </summary>
        /// <param name="empName">名前</param>
        /// <param name="empPass">パスワード</param>
        public void BreakStartInsert(string empName, int empPass)
        {
            var selectEmp = this.SelectEmp(empName, empPass);

            if (selectEmp.Count().Equals(0))
            {
                return;
            }

            using (var db = new GoingToWorkAppContext())
            {
                var workDateEmpName = db.WorkDate.Where(x => x.EmpName.Equals(empName))
                                                  .Where(x => x.WorkStart != null)
                                                   .Where(x => x.BreakStart == null)
                                                    .Where(x => x.BreakEnd == null) 
                                                     .Where(x => x.WorkEnd == null).ToList();

                if (workDateEmpName.Count.Equals(0))
                {
                    return;
                }

                workDateEmpName.Select(x => x.BreakStart = DateTime.Now).ToList();
                db.SaveChanges();
            }
        }


        /// <summary>
        /// 休憩終了時刻を記録
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        public void BreakEndInsert(string empName, int empPass)
        {
            var selectEmp = this.SelectEmp(empName, empPass);

            if (selectEmp.Count().Equals(0))
            {
                return;
            }

            using (var db = new GoingToWorkAppContext())
            {
                var workDateEmpName = db.WorkDate.Where(x => x.EmpName.Equals(empName))
                                                  .Where(x => x.WorkStart != null)
                                                   .Where(x => x.BreakStart != null)
                                                    .Where(x => x.BreakEnd == null)
                                                     .Where(x => x.WorkEnd == null).ToList();

                if (workDateEmpName.Count.Equals(0))
                {
                    return;
                }

                workDateEmpName.Select(x => x.BreakEnd = DateTime.Now).ToList();

                db.SaveChanges();
            }
        }


        /// <summary>
        /// 退勤時刻を記録
        /// </summary>
        /// <param name="empName">名前</param>
        /// <param name="empPass">パスワード</param>
        public void WorkEndInsert(string empName, int empPass)
        {
            var selectEmp = this.SelectEmp(empName, empPass);

            if (selectEmp.Count().Equals(0))
            {
                return;
            }

            using (var db = new GoingToWorkAppContext())
            {
                var breakCheck = db.WorkDate.Where(x => x.EmpName.Equals(empName))
                                             .Where(x => x.BreakStart != null)
                                              .Where(x => x.BreakEnd == null).ToList();

                if (!breakCheck.Count.Equals(0))
                {
                    MessageBox.Show("この従業員は現在休憩中です。\n退勤するには休憩を終了して下さい。",
                                     "確認画面",
                                      MessageBoxButtons.OK,
                                       MessageBoxIcon.Exclamation);
                    return;
                }


                //出勤時間が記録され、かつ退勤記録がないものを検索
                var workDateEmpName = db.WorkDate.Where(x => x.EmpName.Equals(empName))
                                                  .Where(x => x.WorkStart != null)
                                                   .Where(x => x.WorkEnd == null).ToList();

                if (workDateEmpName.Count.Equals(0))
                {
                    return;
                }

                workDateEmpName.Select(x => x.WorkEnd = DateTime.Now).ToList();

                var emp = db.Emp.Where(x => x.EmpName.Equals(empName))
                            　　 .Where(x => x.EmpPassword.Equals(empPass)).ToList();

                emp.Select(x => x.IsGoingToWork = false).ToList();

                db.SaveChanges();
            }
        }

        /// <summary>
        /// 新規従業員登録
        /// </summary>
        /// <param name="name">名前</param>
        /// <param name="pass">パスワード</param>
        /// <param name="birth">生年月日</param>
        /// <returns>登録可能な情報はTrue、不可能ならfalseを返します。</returns>
        public bool AddEmp(string name, int pass, DateTime birth, bool authority)
        {
            using (var db = new GoingToWorkAppContext())
            {
                var userCheck = db.Emp.Where(x => x.EmpName.Equals(name))
                                       .Where(x => x.EmpPassword.Equals(pass))
                                        .ToList();

                //既に登録されている従業員の場合
                if (userCheck.Count >= 1)
                    return false;
                
                //登録処理
                db.Emp.Add(new Emp()
                {
                    EmpName = name,
                    EmpPassword = pass,
                    EmpBirth = birth,
                    IsGoingToWork = false,
                    Authority = authority,
                });

                db.SaveChanges();

                //登録できた場合
                return true;
            }
        }

    }
}

