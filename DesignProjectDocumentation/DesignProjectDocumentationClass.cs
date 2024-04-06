/* Title:           Design Project Documentation
 * Date:            1-15-18
 * Author:          Terry Holmes
 * 
 * Description:     This is the class that is from the documentation */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace DesignProjectDocumentation
{
    public class DesignProjectDocumentationClass
    {
        //setting up the class
        EventLogClass TheEventLogClass = new EventLogClass();

        DesignProjectDocumentationDataSet aDesignProjectDocumentationDataSet;
        DesignProjectDocumentationDataSetTableAdapters.designprojectdocumentationTableAdapter aDesignProjectDocumentationTableAdapter;

        InsertDesignProjectDocumentationEntryTableAdapters.QueriesTableAdapter aInsertDesignProjectDocumentationTableAdapter;

        FindDesignProjectDocumentationByProjectIDDataSet aFindDesignProjectDocumentationByProjectIDDataSet;
        FindDesignProjectDocumentationByProjectIDDataSetTableAdapters.FindDesignProjectDocumentationByProjectIDTableAdapter aFindDesignProjectDocumentationByProjectIDTableAdapter;

        public FindDesignProjectDocumentationByProjectIDDataSet FindDesignProjectDocumentationByProjectID(int intProjectID)
        {
            try
            {
                aFindDesignProjectDocumentationByProjectIDDataSet = new FindDesignProjectDocumentationByProjectIDDataSet();
                aFindDesignProjectDocumentationByProjectIDTableAdapter = new FindDesignProjectDocumentationByProjectIDDataSetTableAdapters.FindDesignProjectDocumentationByProjectIDTableAdapter();
                aFindDesignProjectDocumentationByProjectIDTableAdapter.Fill(aFindDesignProjectDocumentationByProjectIDDataSet.FindDesignProjectDocumentationByProjectID, intProjectID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Design Project Documentation // Find Design Project Documentation By Project ID " + Ex.Message);
            }

            return aFindDesignProjectDocumentationByProjectIDDataSet;
        }
        public bool InsertDesignProjectDocumentation(int intProjectID, int intEmployeeID, DateTime datTransactionDate, string strDocumentType, string strDocumentPath)
        {
            bool blnFatalError = false;

            try
            {
                aInsertDesignProjectDocumentationTableAdapter = new InsertDesignProjectDocumentationEntryTableAdapters.QueriesTableAdapter();
                aInsertDesignProjectDocumentationTableAdapter.InsertDesignProjectDocumentation(intProjectID, intEmployeeID, datTransactionDate, strDocumentType, strDocumentPath);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Design Project Documentation // Insert Design Project Documentation " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public DesignProjectDocumentationDataSet GetDesignProjectDocumentationInfo()
        {
            try
            {
                aDesignProjectDocumentationDataSet = new DesignProjectDocumentationDataSet();
                aDesignProjectDocumentationTableAdapter = new DesignProjectDocumentationDataSetTableAdapters.designprojectdocumentationTableAdapter();
                aDesignProjectDocumentationTableAdapter.Fill(aDesignProjectDocumentationDataSet.designprojectdocumentation);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Design Project Documentation // Get Design Project Documentation Info " + Ex.Message);
            }

            return aDesignProjectDocumentationDataSet;
        }
        public void UpdateDesignProjectDocumentationDB(DesignProjectDocumentationDataSet aDesignProjectDocumentationDataSet)
        {
            try
            {
                aDesignProjectDocumentationTableAdapter = new DesignProjectDocumentationDataSetTableAdapters.designprojectdocumentationTableAdapter();
                aDesignProjectDocumentationTableAdapter.Update(aDesignProjectDocumentationDataSet.designprojectdocumentation);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Design Project Documentation // Update Design Project Documentation DB " + Ex.Message);
            }
        }
    }
}
