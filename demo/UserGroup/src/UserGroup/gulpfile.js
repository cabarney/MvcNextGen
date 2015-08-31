/// <binding Clean='clean' />

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    less = require("gulp-less"),
    rename = require('gulp-rename'),
    sourcemaps = require("gulp-sourcemaps"),
    project = require("./project.json");

var paths = {
    webroot: "./" + project.webroot + "/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.bower = "./bower_components/";
paths.lib = paths.webroot + "lib/";
paths.less = paths.webroot + "css/**/*.less";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean:lib", function (cb) {
    rimraf(paths.lib, cb);
});

gulp.task("clean", ["clean:js", "clean:css", "clean:lib"]);

gulp.task('copy:bower', function () {
    var bower = {
        "jquery": "jquery/dist/*.{js,map}",
        "bootstrap": "bootstrap/dist/**/*.{js,map,css,ttf,svg,woff,eot}",
        "bootstrap-touch-carousel": "bootstrap-touch-carousel/dist/**/*.{js,map,css}",
        "jquery-validation": "jquery-validation/jquery.validate.js",
        "jquery-validation-unobtrusive": "jquery-validation-unobtrusive/jquery.validate.unobtrusive.js",
        "hammer.js": "hammer.js/*.{js,map}"
    };

    for (var destinationDir in bower) {
        gulp.src(paths.bower + bower[destinationDir])
          .pipe(gulp.dest(paths.lib + destinationDir));
    };
});


gulp.task("min:js", function () {
    gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", ["compile:less"], function () {
    gulp.src([paths.css, "!" + paths.minCss])
        .pipe(cssmin())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(paths.webroot + "css/"));
});


gulp.task('compile:less', function () {
    return gulp.src([paths.less], {base:'.'})
        .pipe(sourcemaps.init())
        .pipe(less())
        .pipe(sourcemaps.write())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);


gulp.task('watch:less', function () {
    gulp.watch([paths.less], ['min:css']);
});