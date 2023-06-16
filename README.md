# CircadApp
App for the “street circus” Circada Festival celebrated annually in Seville. Written in .Net Maui.

The original idea was to provide an app where the user can have the festival schedule and artist information at hand. However, this was solved by embedding the website of the festival, saving a lot of development time. We then used the saved resources to develop a quiz about street circus that is having a good reception among its aficionados.

We are currently measuring the app engagement and planning where to go next.

# Video
A demo video:

https://github.com/salvadorjesus/CircadApp/assets/637125/87e19e8d-1990-4bf5-95e9-d1bcd8776b7b

# Download
Currently the app is available on the Google Play Store:

<a href='https://play.google.com/store/apps/details?id=com.LaSibilaPatrimonio.ElPuertodelosCargadoresaIndias&gl=ES&pcampaignid=pcampaignidMKT-Other-global-all-co-prtnr-py-PartBadge-Mar2515-1'><img width="250" alt='Get it on Google Play' src='https://play.google.com/intl/en_us/badges/static/images/badges/en_badge_web_generic.png'/></a>

# Loose schema
A non-standard schema to quickly wrap your head around the project files and structure:

![Loose schema 1](https://github.com/salvadorjesus/CircadApp/assets/637125/9473148b-036d-49bf-953d-c5b65cb5e6ab)

### Brief summary
Quiz questions are stored in a JSON file. Every question has a title and four response options, with only one of them being the correct response. Every question can have an image (stored on disk as part of the app raw data).

The QuizPageViewModel loads a quiz from disk using the QuizService class and warps the questions data with several ViewModel classes that add observable and responsive properties to the quiz raw data. In this way, the View can react to user inputs and render the question buttons with different styles, animations, etc.

User score is reevaluated every time the user completes a quiz, showing the user a Lottie animation. It is saved to disk safely by serializing the Model objects to a JSON file using the UserScoreService class. The user score is presented to the users as small trophies in the QuizStartPage.

The weak reference messenger is used to notify the QuizPage that the shell is trying to navigate away from the quiz. If the quiz is not ye completed, the user is asked for confirmation.
