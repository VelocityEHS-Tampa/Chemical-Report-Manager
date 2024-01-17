This is a file added to the project that will be checked on every publish to determine if an update has been pushed.


*Fix Links to PDFs (06/01/2023)
*Fix Missed Links to PDFs, disable Send Email button on GLO Email Form (06/01/2023)
*Fixed Crestwood General Incident Incident Date Field. Add error logs, emails, and Error screen redirects to submitting forms. (06/02/2023)

Bug Fix Update 06/07/2023
* Add subject line containing GLO ID to CRM Email Logs.
* Add GLO County Search functionality to the program.
* Make GLO County landing page show all records instead of 50
* Correct Back to Report button on Crestwood reports to stop the creation of new IDs.
* Correct misspelled email address in crestwood emails.

Weekly Update (06/12/2023)
* MSDS Search
* Add Local-PSG-TX-Corp@crestwoodlp.com to Crestwood Non Transport email list.

Weekly Update (06/19/2023)
* New error message when GLO fails to commit.
* Add "maxlength" to GLO textboxes that are getting overfilled and breaking.
* Get latest ID from generalincidentreportdata database table instead of "OtherIDs" table. Streamlining and making the process even more efficient.
* Add AJAX Call to run every 5 seconds for a new Gen Inc ID number. If it changes, update the Incident ID Field and alert the ERS Operator.

Weekly Update (06/26/2023)
* Make all "Back To Report" links into small form to go back to same report instead of creating new IDs. Making consistent across the board. (Shell Oil and General Incidents)
* Create an alert to make sure an Incident Type is selected for Crestwood General Incident.
* Make amount spilled default 0.00 visible instead of just backend in GLO.
* Make all times in GLO 0000 visible instead of just backend.
* Fix submit/update buttons to actually NOT submit when clicking "Cancel" on the pop up.
* Make NON-COASTAL field has a selection before submitting report.

Weekly Update (07/10/2023)
* Make phone number in General Incident default populate to (000) 000-0000
* Fix Call Date in Crest General Incident from populating to today's date when revising report.

Weekly Update (07/24/2023)
* Add "ers@ehs.com" to automatically be added to the email list in the back end in case they get erased.
* Remove "mpepitone@ehs.com" & "ers@ehs.com" from populating in the text box when sending out a GLO email.
* Correct issue that will not pass Canada Providences to the PDF report for General Incidents

Weekly Update (07/31/2023)
* Add Advacned Search Options in MSDS Search for Second Search term, Sort By, and Sorting Order (A-Z0-9) or (Z-A9-0)
* Increase File size limit in emails to 1 GB 
* Added missing variable to GLO Report to keep entered in "Receiving Water" values instead of "N/A"

Weekly Update (08/10/2023)
* Novartis Registration Lookup added to menu bar on top of the page.
* Hotfix for Crestwood Locked Gate 

Weekly Update (08/28/2023)
* Do not select "A Core Emails" when "GLO HQ" is selected when sending out a GLO report.
* Change URL variable in GLO Commit AJAX call to be URl.Action rather than an absolute path. (to hopefully stop 404 ajax calls)

Weekly Update (09/11/2023)
* Change GLO Commit Report to be a form submission instead of AJAX Call
* Replace ChemTel Incident Report with VelocityEHS Incident Report

Weekly Update (10/05/2023)
* Add error message to home screen indicating email has or has not been sent out.
* Change login verbiage to Good Morning, Afternoon, Evening.
* Correct the UNK value in Cleanshot to actually show UNK and not NO

Hotfix Update (10/17/2023)
* Remove the database inserts and updates for the DOT questions to allow for a database insert.

Hotfix Update (10/25/2023) 
* Change EPA Reg # textbox Value to be placeholder to avoid removing it when going back. (General Incident Reports.)
* Remove code for file modification checks.
* Remove transportation code from back end functions to allow all emails to show up.

Weekly Update (11/05/2023)
* Added .Trim() to email lists to ensure empty commas do not cause problems.
* Add message after sending out an email letting users know if their emails were sent or not.
* Set automatically generated report time hours back an hour for time change.