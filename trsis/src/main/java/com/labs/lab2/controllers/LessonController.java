package com.labs.lab2.controllers;

import com.labs.lab2.model.Lesson;
import com.labs.lab2.service.LessonService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.util.List;

@RestController
public class LessonController {
    private final LessonService lessonService;

    @Autowired
    public LessonController(LessonService lessonService) {
        this.lessonService = lessonService;
    }

    @PostMapping(value = "public/rest/lessons")
    public ResponseEntity<?> create(@RequestBody Lesson lesson) {
        lessonService.create(lesson);
        return new ResponseEntity<>(HttpStatus.CREATED);
    }

    @GetMapping(value = "public/rest/lessons")
    public ResponseEntity<List<Lesson>> read() {
        final List<Lesson> lessons = lessonService.readAll();

        return lessons != null && !lessons.isEmpty()
                ? new ResponseEntity<>(lessons, HttpStatus.OK)
                : new ResponseEntity<>(HttpStatus.OK);
    }

    @GetMapping(value = "public/rest/lessons/{id}")
    public ResponseEntity<Lesson> read(@PathVariable(name = "id") int id) {
        final Lesson lesson = lessonService.read(id);

        return lesson != null
                ? new ResponseEntity<>(lesson, HttpStatus.OK)
                : new ResponseEntity<>(HttpStatus.NOT_FOUND);
    }

    @PutMapping(value = "public/rest/lessons/{id}")
    public ResponseEntity<?> update(@PathVariable(name = "id") int id, @RequestBody Lesson lesson) {
        final boolean updated = lessonService.update(lesson, id);

        return updated
                ? new ResponseEntity<>(HttpStatus.OK)
                : new ResponseEntity<>(HttpStatus.NOT_MODIFIED);
    }

    @DeleteMapping(value = "public/rest/lessons/{id}")
    public ResponseEntity<?> delete(@PathVariable(name = "id") int id) {
        final boolean deleted = lessonService.delete(id);

        return deleted
                ? new ResponseEntity<>(HttpStatus.OK)
                : new ResponseEntity<>(HttpStatus.NOT_MODIFIED);
    }
}
