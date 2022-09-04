import React, { Component } from 'react';
import { Form, FormGroup, Input, Button, Label, Col, Alert } from 'reactstrap';
import MDEditor from '@uiw/react-md-editor';

export class Medium extends Component {
    static displayName = Medium.name;

    constructor(props) {
        super(props);

        this.state = {
            title: '',
            text: '',
            isSent: false,
            isError: false,
            isTitleValid: undefined,
            isTextValid: undefined
        };

        this.handleTitleChange = this.handleTitleChange.bind(this);
        this.handleTextChange = this.handleTextChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleTitleChange(e) {
        this.setState({
            title: e.target.value,
            isTitleValid: !!e.target.value // falsy -- "" ~ false -> !"" === true -> !true == false
        });
    }

    handleTextChange(text) {
        this.setState({
            text: text.target.value,
            isTextValid: !!text.target.value
        });
    }

    handleSubmit(e) {
        e.preventDefault();

        if (this.validateFields()) {
            fetch('/mediumservice',
                {
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    method: "POST",
                    body: JSON.stringify(
                        {
                            Title: this.state.title,
                            Text: this.state.text
                        })
                })
                .then(response => {
                    if (response.ok) {                        
                        return response.text();
                    }
                    else {
                        this.setState({
                            isError: true,
                            isSent: false
                        });
                    }
                })
                .then(text => {
                    this.setState({
                        title: '',
                        text: '',
                        isSent: true,
                        isError: false,
                        lastPostLink: text
                    });
                })
                .catch(response => {
                    this.setState({
                        isError: true,
                        isSent: false
                    });
                })
        }
    }

    validateFields() {
        var isValid = true;

        if (!this.state.title || !this.state.text) { // title -> undefined, '', null ...
            this.setState({
                isTitleValid: false,
                isTextValid: false
            })

            isValid = false;
        }

        return isValid;
    }

    render() {
        return (
            <div>

                <Alert isOpen={this.state.isSent} fade>
                    Спасибо, <a target="_blank" href={this.state.lastPostLink}>статья</a> отправлена!
                </Alert>

                <Alert isOpen={this.state.isError} color="danger">
                    Произошла ошибка!
                </Alert>

                <Form onSubmit={this.handleSubmit}>
                    <FormGroup row className='mb-3'>
                        <Label for="title" sm={2}>
                            Заголовок
                        </Label>
                        <Col sm={10}>
                            <Input
                                invalid={this.state.isTitleValid === false ? true : undefined}
                                id="title"
                                name="title"
                                type="text"
                                value={this.state.title}
                                onChange={this.handleTitleChange}
                            />
                        </Col>
                    </FormGroup>
                    {' '}
                    <FormGroup row className='mb-3'>
                        <Label for="text" sm={2}>
                            Текст
                        </Label>
                        <Col sm={10}>
                            <Input
                                invalid={this.state.isTextValid === false ? true : undefined}
                                value={this.state.text}
                                onChange={this.handleTextChange} />
                            {/*<MDEditor.Markdown source={this.state.text} style={{ whiteSpace: 'pre-wrap' }} />*/}
                        </Col>
                    </FormGroup>
                    {' '}
                    <FormGroup row className='mb-3'>
                        <Label for="file" sm={2}>
                            Изображение
                        </Label>
                        <Col sm={10}>
                            <Input
                                id="file"
                                name="file"
                                type="file"
                            />
                        </Col>
                    </FormGroup>
                    {' '}
                    <Button>
                        Создать
                    </Button>
                </Form>
            </div>
        );
    }
}
