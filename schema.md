Survey 
- Id
- Name
- FKs to the questions

SurveyQuestion
- Id
- SurveyId (FK to survey)
- Title
- Description
- Options? (for radios or other selectable options)

SurveyResponse
- Id
- SurveyId (no FK, in case the survey is deleted? Do we want to keep the response?)
- UserId
- QuestionTitle (copy from survey, in case questions change later)
- QuestionDesription (same)
- Response

User
- Id
- Email

