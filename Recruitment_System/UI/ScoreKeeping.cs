using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Recruitment_System.BL;

namespace Recruitment_System.UI
{
    public partial class ScoreKeeping : Form
    {
        public ScoreKeeping(Interviewer interviewer, Nominee nominee)
        {
            InitializeComponent();
            Text = "ציונים עבור " + nominee.ToString();

            NomineeScoreTypeArr nomineeScoreTypeArr = new NomineeScoreTypeArr();
            nomineeScoreTypeArr.Fill();
            nomineeScoreTypeArr = nomineeScoreTypeArr.Filter(interviewer, nominee, ScoreType.Empty, 0, DateTime.MinValue, DateTime.MaxValue);

            nomineeScoreTypeArr = FillData(nomineeScoreTypeArr, nominee, interviewer);

            scorer1.SetDataSource(nomineeScoreTypeArr);
        }


        private NomineeScoreTypeArr FillData(NomineeScoreTypeArr nomineeScoreTypeArr, Nominee nominee, Interviewer interviewer)
        {
            //
            PositionNomineeArr positionNomineeArr = new PositionNomineeArr();
            positionNomineeArr.Fill();
            positionNomineeArr = positionNomineeArr.Filter(nominee, Position.Empty);

            PositionArr positionArr = positionNomineeArr.ToPositionArr();
            //

            ScoreTypeArr scoreTypeArr = new ScoreTypeArr();

            Position position;
            ScoreType scoreType;
            NomineeScoreType nomineeScoreType;
            for (int i = 0; i < positionArr.Count; i++)
            {
                position = positionArr[i] as Position;

                scoreTypeArr.Fill();
                scoreTypeArr = scoreTypeArr.Filter(position, "");

                for (int j = 0; j < scoreTypeArr.Count; j++)
                {
                    scoreType = scoreTypeArr[j] as ScoreType;

                    if (!nomineeScoreTypeArr.DoesContainData(interviewer, nominee, scoreType))
                    {
                        nomineeScoreType = new NomineeScoreType();
                        nomineeScoreType.Interviewer = interviewer;
                        nomineeScoreType.Nominee = nominee;
                        nomineeScoreType.ScoreType = scoreType;
                        nomineeScoreType.DateTime = DateTime.Now;

                        nomineeScoreTypeArr.Add(nomineeScoreType);
                    }
                }
            }
            return nomineeScoreTypeArr;
        }

        public NomineeScoreTypeArr FormToNomineeScoreTypeArr()
        {
            return scorer1.GetData();
        }
    }
}
